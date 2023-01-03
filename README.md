# Model Compiler #
The [OPC Foundation](https://opcfoundation.org) Model Compiler will generate C# and ANSI C source code from XML files which include the UA Services, data-types, error codes, etc.; and numerous CSV files that contain NodeIds, error codes, and attributes etc.

The input format for the tool is a file that conforms to the schema defined in UA Model Design.xsd. 

**2022-10-15: the tool now supports Part 6 Annex F (a.k.a. NodeSet2) as a syntax for the input files [see schema](https://github.com/OPCFoundation/UA-Nodeset/blob/latest/Schema/UANodeSet.xsd).**  

The output of the tool includes:
 1. A NodeSet which conforms to the schema defined in Part 6 Annex F;
 2. An XSD and BSD (defined in Part 3 Annex C)  that describes any datatypes;
 3. Class and constant definitions suitable for use with the .NET sample libraries;
 4. Other data files used to load an information model into a Server built with the .NET sample libraries;
 5. A CSV file which contains numeric identifiers. 

The [UA Model Design.xsd](https://github.com/OPCFoundation/UA-ModelCompiler/blob/master/Opc.Ua.ModelCompiler/UA%20Model%20Design.xsd) has more information about the schema itself.

The .NET sample libraries has [a sample Model Design file](https://github.com/OPCFoundation/UA-.NET/blob/master/SampleApplications/Samples/Common/Sample/SampleDesign.xml) that illustrate how to create a user defined model.
This [batch file](https://github.com/OPCFoundation/UA-.NET/blob/master/SampleApplications/Samples/Common/BuildDesign.bat) is used to regenerate the files used in the sample after changes.

The tool only produces ANSI C output for the stack.

All of the standard outputs are published in the [Nodeset GitHub repository](https://github.com/OPCFoundation/UA-Nodeset)

Developers should never need to build the standard outputs themselves.

**2022-10-15: The following tutorial is out of date due to changes needed to support NodeSet2 as an input format.**<br/>
Tutorial by Stefan Profanter [here](https://opcua.rocks/custom-information-models/).

Command line parameters for ModelDesigns or NodeSets:
```
Takes an OPC UA ModelDesign file and generates a NodeSet and code for the .NETStandard stack.

Usage: ModelCompiler compile [options]

Options:
  -?|-h|--help       Show help information.
  -d2                The path to the ModelDesign or NodeSet2 file which contains the UA information model. The first
                     file specified is the model to generate. The rest are included models. The file path may be
                     followed by the namespace prefix and a short name for model. Commas seperate each field.
  -c                 The path to the CSV file which contains the unique identifiers for the types defined in the UA
                     information model. Not used if the target is a NodeSet2 file.
  -cg                Creates the identifier file if it does not exist (used instead of the -c option).
  -o2                The output directory for the generated files.
  -ansic             The path to use when generating ANSI C stack code (internal use only).
  -stack             The path to use when generating .NET stack code (internal use only).
  -version           Selects the source for the input files. v103 | v104 | v105 are supported.
  -useAllowSubtypes  When subtypes are allowed for a field, C# code with the class name from the model is created
                     instead of ExtensionObject. No effect when subtypes are not allowed.
  -id                The first identifier to use when assigning new ids to nodes.
  -exclude           Comma seperated list of ReleaseStatus values to exclude from output.
  -mv                The version of the model to produce.
  -pd                The publication date of the model to produce.
  -rc                Indicates that a release candidate nodeset is being generated.
```

Example
```
Opc.Ua.ModelCompiler compile -d2 .\Opc.Ua.Machinery.NodeSet2.xml,Opc.Ua.Machinery,Machinery -d2 Opc.Ua.Di.NodeSet2.xml,Opc.Ua.DI,DI -version v105 -exclude Draft -o2 .\output
```

Command line parameters for NodeSets based on URIs rather than files:
```
Searches a directory tree for nodesets and generates code for the specified model URIs.

Usage: ModelCompiler compile-nodesets [options]

Options:
  -?|-h|--help  Show help information.
  -input        The path to the directory containing the nodesets.
  -o2           The path to the directory to use to write the generated files.
  -uri          The URI of the model to generate.
```

Example
```
Opc.Ua.ModelCompiler compile-nodesets -input .\v105\ -o2 .\Tests -uri http://opcfoundation.org/UA/Machinery/ -uri http://opcfoundation.org/UA/IA/ -uri http://opcfoundation.org/UA/DI/
```	
			
## Version History ##

|Version|Changes|
|--|--|
|2.0|Intial release with version tracking and .NET 5.0 support.|
|2.1|Added UA 1.05.00 support.<br/>Switched to Microsoft.Extensions.CommandLineUtils.<br/>Arguments are the same, however, the command 'compile' must be specified.<br/>Use --help for more details.<br/>Fixed bug in generating the 'uanodes' input for the .NET codebase.|
|2.2|Added UA 1.05.02 support.<br/>Added support for NodeSet2 input format.<br/>Added DisplayName to enumeration fields.<br/>Add Union/OptionalFields Support.<br/>Add IJsonEncodeable interface.<br/>Remove unnecessary descriptions in autogenerated code.<br/>Add -compile-nodesets command|

The executable file version has the form 2.0.YYMM.DDHH where the last two fields are based on the time that it was built.

## About this Repository ##
Please clone this repository as shown:
```
git clone https://github.com/OPCFoundation/UA-ModelCompiler
```
There are submodules which non-members will not have access to if the --recursive flag is specified. 

The 'ModelCompiler Solution.sln' solution does not require these submodules.

**If access to the submodules is denied then leave --recursive flag off and only use the 'ModelCompiler Solution.sln' which uses NuGet packages instead of the submodules.**

This repository is not updated directly. All changes are first made in a member-only version that can be found [here](https://github.com/OPCF-Members/UA-ModelCompiler).

The version in the member-only repository includes content that is only available to OPC Foundation members such as draft versions of the specifications. When a new version of the OPC UA specification is released, the member-only content is removed and copied to the public repository. 

In many cases, updates to the UA-ModelCompiler will require updates to [UA-.NETStandard](https://github.com/OPCFoundation/UA-.NETStandard) codebase. This means a complete release of the UA-ModelCompiler will need to wait for a update to UA-.NETStandard NuGet packages. The member only version links to a member only fork of [UA-.NETStandard](https://github.com/OPCF-Members/UA-.NETStandard-Prototypes) allows the changes to be viewed before they are merged with the public baseline.

The public repository is updated as frequently as the OPC UA Specification (once every 3-5 months). When a release starts, all issues reported on the public repository will be reviewed and, if appropricate, incorporated into the member-only codebase. This includes any pull requests to this public repository, which are subject to the [OPC Foundation Contributor License Agreement (CLA)](https://cla-assistant.io/OPCFoundation/UA-ModelCompiler). When the process completes all accepted public contributions will be merged back into the public codebase along with updates from the member-only codebase.

## License Model ##

The ModelCompiler code is [MIT license](https://github.com/OPCFoundation/UA-ModelCompiler/blob/master/license.md), however, it links to the UA-.NETStandard NuGet packages which is covered under the [OPC Foundation Redistributables licence](https://opcfoundation.org/license/redistributables/1.3/index.html). If a user chooses the version that links directly to the  UA-.NETStandard submodule then the license the UA-.NETStandard [dual license](https://github.com/OPCFoundation/UA-.NETStandard/blob/master/LICENSE.txt) applies. 
  
## Docker Build

A Docker build with the UA Model Compiler is available in GitHub as [ua-modelcompiler](https://github.com/OPCFoundation/UA-ModelCompiler/pkgs/container/ua-modelcompiler).

It can be downloaded with this command:
```
docker pull ghcr.io/opcfoundation/ua-modelcompiler:latest
```

You may need to use this command before downloading the docker image:
```
docker login ghcr.io -u <user> -p <person access token>
```

Running the image requires a local directory with the source files which is specified with the -v option (the %CD% is using Windows cmd prompt syntax. Use $(pwd) if using bash). The following command is run from the directory where the source files are:

```
docker run -v %CD%:/data --rm ghcr.io/opcfoundation/ua-modelcompiler:latest compile -d2 /data/Opc.Ua.Di.NodeSet2.xml,Opc.Ua.DI,DI -o2 /data/generated 
```

The tool can also automatically find all NodeSet dependencies if it is run from a directory with all necessary NodeSets (i.e. [UA-Nodeset](https://github.com/OPCFoundation/UA-Nodeset)). The command to run from the nodeset directory is:

```
run -v %CD%:/nodesets --rm ghcr.io/opcfoundation/ua-modelcompiler:latest compile-nodesets -input /nodesets -o2 /nodesets/generated -uri http://opcfoundation.org/UA/Machinery/ -uri http://opcfoundation.org/UA/DI/
```

The docker image can be rebuilt from source with this command:

```
docker build -t opcua-modelcompiler .
```

## Example Generation ##
The following process will demonstrate how to generate code using the supplied nodeset files:
 1. Clone the repository and then build the source in Visual Studio 2022, in Release mode.
 2. Open a Command prompt and then launch the BuildStandardTypes.bat
 3. After the script completes, navigate to the .\Published folder to view the output.
 4. Optionally, modify the BAT file and specify the location of your UA Stack(s) to automatically copy the generated files.

### XML Files ###
#### Model Design example ####
An excerpt of the Model Design file is shown here:
```xml
<?xml version="1.0" encoding="utf-8" ?>
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

This ModelCompiler is used to generate the content of the [.NET Samples GitHub repository](https://github.com/OPCFoundation/UA-.NETStandard-Samples).
