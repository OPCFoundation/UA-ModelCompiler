# Model Compiler #
The [OPC Foundation](https://opcfoundation.org) Model Compiler will generate C# and ANSI C source code from XML files which include the UA Services, data-types, error codes, etc.; and numerous CSV files that contain NodeIds, error codes, and attributes etc.

The input format for the tool is a file that conforms to the schema defined in UA Model Design.xsd. 

The output of the tool includes:
 1. A NodeSet which conforms to the schema defined in Part 6 Annex F;
 2. An XSD and BSD (defined in Part 3 Annex C)  that describes any datatypes;
 3. Class and constant definitions suitable for use with the .NET sample libraries;
 4. Other data files used to load information info into a Server built with the .NET sample libraries;
 5. A CSV file which contains numeric identifiers. 

The [UA Model Design.xsd] (https://github.com/OPCFoundation/UA-ModelCompiler/blob/master/ModelCompiler/UA%20Model%20Design.xsd) has more information about the schema itself.

The .NET sample libraries has [a sample Model Design file] (https://github.com/OPCFoundation/UA-.NET/blob/master/SampleApplications/Samples/Common/Sample/SampleDesign.xml) that illustrate how to create a user defined model.
This [batch file](https://github.com/OPCFoundation/UA-.NET/blob/master/SampleApplications/Samples/Common/BuildDesign.bat) is used to regenerate the files used in the sample after changes.

The tool only produces ANSI C output for the stack.

All of the standard outputs are published in the [Nodeset GitHub repository](https://github.com/OPCFoundation/UA-Nodeset)

Developers should never need to build the standard outputs themselves.

## About this Repository ##
This repository contains *sub-modules* for the Nodeset files, which are independently tracked. Please clone this repository as shown:
```
git clone https://github.com/OPCFoundation/UA-ModelCompiler --recursive
```

## Example Generation ##
The following process will demonstrate how to generate code using the supplied nodeset files:
 1. Clone the repository and then build the source in Visual Studio 2015, in Release mode.
 2. Open a Command prompt and then launch the BuildStandardTypes.bat
 3. After the script completes, navigate to the .\Published folder to view the output.
 4. Optionally, modify the BAT file and specify the location of your UA Stack(s) to automatically copy the generated files.

### XML Files ###
#### Model Design example ####
An excerpt of the Model Design file is shown here:
```
?xml version="1.0" encoding="utf-8" ?>
<opc:ModelDesign
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns:xsd="http://www.w3.org/2001/XMLSchema"
  xmlns:opc="http://opcfoundation.org/UA/ModelDesign.xsd"
  xmlns:ua="http://opcfoundation.org/UA/"
  xmlns="http://opcfoundation.org/UA/"
  xmlns:uax="http://opcfoundation.org/UA/2008/02/Types.xsd"
  TargetNamespace="http://opcfoundation.org/UA/"
  TargetNamespaceVersion="1.02"
>
  <opc:Namespaces>
    <opc:Namespace Name="OpcUa" Prefix="Opc.Ua" InternalPrefix="Opc.Ua.Server" XmlNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd">http://opcfoundation.org/UA/</opc:Namespace>
  </opc:Namespaces>

  <opc:Property SymbolicName="NodeVersion" DataType="ua:String" PartNo="3">
    <opc:Description>The version number of the node (used to indicate changes to references of the owning node).</opc:Description>
  </opc:Property>

  <opc:Property SymbolicName="ViewVersion" DataType="ua:UInt32" PartNo="3">
    <opc:Description>The version number of the view.</opc:Description>
  </opc:Property>
```
## Other Repositories ##
This ModelCompiler is used to generate the content of the [Nodeset GitHub repository](https://github.com/OPCFoundation/UA-Nodeset).

This ModelCompiler is used to generate the content of the [.NET Samples GitHub repository](https://github.com/OPCFoundation/UA-.NET).
