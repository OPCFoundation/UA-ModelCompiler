using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCompiler
{
    public static class SemanticVersion
    {
        public static string Create(string version)
        {
            if (String.IsNullOrWhiteSpace(version))
            {
                return null;
            }

            var fields = version.Split('.');

            StringBuilder output = new();

            foreach (var field in fields)
            {
                string suffix = null;

                if (!UInt32.TryParse(field, out var element))
                {
                    for (int ii = 0; ii < field.Length; ii++)
                    {
                        if (field[ii] == '+' || field[ii] == '-')
                        {
                            suffix = field.Substring(ii);
                            UInt32.TryParse(field.Substring(0, ii), out element);
                            break;
                        }
                    }
                }

                if (output.Length > 0)
                {
                    output.Append('.');
                }

                output.Append(element);

                if (suffix != null)
                {
                    output.Append(suffix);
                }
            }

            while (output.ToString().Where(x => x == '.').Count() < 2)
            {
                output.Append(".0");
            }

            return output.ToString();
        }
    }
}
