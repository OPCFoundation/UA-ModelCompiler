# Model Compiler #
The [OPC Foundation](https://opcfoundation.org) Model Compiler will generate C# and ANSI C source code from XML files which include the UA Services, data-types, error codes, etc.; and numerous CSV files that contain NodeIds, error codes, and attributes etc.

The input format for the tool is a file that conforms to the schema defined in UA Model Design.xsd. 

The output of the tool includes:
 1. A NodeSet which conforms to the schema defined in Part 6 Annex F;
 2. An XSD and BSD (defined in Part 3 Annex C)  that describes any datatypes;
 3. Class and constant definitions suitable for use with the .NET sample libraries;
 4. Other data files used to load an information model into a Server built with the .NET sample libraries;
 5. A CSV file which contains numeric identifiers. 

The [UA Model Design.xsd](https://github.com/OPCFoundation/UA-ModelCompiler/blob/master/ModelCompiler/UA%20Model%20Design.xsd) has more information about the schema itself.

The .NET sample libraries has [a sample Model Design file](https://github.com/OPCFoundation/UA-.NET/blob/master/SampleApplications/Samples/Common/Sample/SampleDesign.xml) that illustrate how to create a user defined model.
This [batch file](https://github.com/OPCFoundation/UA-.NET/blob/master/SampleApplications/Samples/Common/BuildDesign.bat) is used to regenerate the files used in the sample after changes.

The tool only produces ANSI C output for the stack.

All of the standard outputs are published in the [Nodeset GitHub repository](https://github.com/OPCFoundation/UA-Nodeset)

Developers should never need to build the standard outputs themselves.

Tutorial by Stefan Profanter [here](https://opcua.rocks/custom-information-models/).

## About this Repository ##
This repository contains *sub-modules* for the Nodeset files, which are independently tracked. Please clone this repository as shown:
```
git clone https://github.com/OPCFoundation/UA-ModelCompiler --recursive
```

This repository is not updated directly. All changes are first made in a member-only version that can be found [here](https://github.com/OPCF-Members/UA-ModelCompiler).

The version in the member-only repository includes content that is only available to OPC Foundation members such as draft versions of the specifications. When a new version of the OPC UA specification is released, the member-only content is removed and copied to the public reposotory. 

In many cases, updates to the UA-ModelCompiler will require updates to [UA-.NETStandard](https://github.com/OPCFoundation/UA-.NETStandard) codebase. This means a complete release of the UA-ModelCompiler will need to wait for a update to UA-.NETStandard NuGet packages. The member only version links to a member only fork of [UA-.NETStandard](https://github.com/OPCF-Members/UA-.NETStandard-Prototypes) allows the changes to be viewed before they are merged with the public baseline.

The public repository is updated as frequently as the OPC UA Specification (once every 3-5 months). When a release starts, all issues reported on the public repository will be reviewed and, if appropricate, incorporated into the member-only codebase. This includes any pull requests. 

## License Model ##

The ModelCompiler code is [MIT license](https://github.com/OPCFoundation/UA-ModelCompiler/blob/master/license.md), however, it links to the UA-.NETStandard NuGet packages which is covered under the [OPC Foundation Redistributables licence](https://opcfoundation.org/license/redistributables/1.3/index.html). If a user chooses the version that links directly to the  UA-.NETStandard submodule then the license the UA-.NETStandard [dual license](https://github.com/OPCFoundation/UA-.NETStandard/blob/master/LICENSE.txt) applies. 
  

## Docker Build

The compiled version of this model compiler is available in DockerHub as [sailavid/ua-modelcompiler](https://cloud.docker.com/u/sailavid/repository/docker/sailavid/ua-modelcompiler).
TODO: Change URL to use official OPCF Docker container!

If you like to build your own container, just use the provided Dockerfile in this repo.

We assume you have your `myModel.xml` and `myModel.csv` on your host system in `$HOME/myModel`. If not change the path in the next command.

The Docker container uses the model compiler executable as entry point.
This means that any parameter you pass to the `docker run` command will be directly passed to the model compiler executable.

This is an examplary call to docker run:

```bash
docker run \
  --mount type=bind,source=$HOME/myModel,target=/model \
  sailavid/ua-modelcompiler -- \
   -console -d2 /model/myModel.xml -cg /model/myModel.csv -o2 /model/Published/my_model
```

Note that here we are binding `$HOME/myModel` to the path `/model` inside the container.

You need to make sure that the output directory already exists before running this command.

The expected output is:
```
Trying file: /model/OpcUaDiModel.xml
Trying file: ./Design/OpcUaDiModel.xml
Trying file: /model/OpcUaDiModel.csv
Trying file: ./Design/OpcUaDiModel.csv
```

Note, there's no final success message.


To use the `PublishModel.sh` script you can also override the entrypoint. The PublishModel script is a wrapper around the model compiler executable and is handling directory creation and copying the original model files.

```bash
docker run \
  --mount type=bind,source=$HOME/myModel,target=/model \
  --entrypoint "/app/PublishModel.sh" \
  sailavid/ua-modelcompiler \
   /model/myModel my_model /model/Published
```

The expected output is:
```
Building Model for 'my_model'
/app/Opc.Ua.ModelCompiler.exe -console -d2 /model/myModel.xml -cg /model/myModel.csv -o2 /model/Published/my_model
Trying file: /model/OpcUaDiModel.xml
Trying file: ./Design/OpcUaDiModel.xml
Trying file: /model/OpcUaDiModel.csv
Trying file: ./Design/OpcUaDiModel.csv
Copying Model files to /model/Published/my_model

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
