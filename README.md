# Visual Studio Extensibility Templates
This repo contains item templates that help you develop Visual Studio extensions.

We love to hear your feedback! Add templates you would like to see as Issues. Also we welcome pull requests to improve existing or add new templates. Check out the contributing guidelines.

Templates currently included:

* CommandHandlerTemplate - Add a command handler and hook it up to Visual Studio.
* OptionsPageTemplate - Add a page to the Visual Studio options dialog.
* WpfTextViewCreationListenerTemplate - Create a basic implementation of IWpfTextViewCreationListener.

## How to use the templates
* Clone the repository
* Build vsix
* Install vsix

## Creating a template

To create a template, you need to add a new project template or item template project to the VSSDKTemplates.sln. For it to show up in the extension, make sure you add it to the [source.extension.vsixmanifest](https://github.com/Microsoft/VSSDK-Extensibility-Templates/blob/master/src/source.extension.vsixmanifest) as well.

### Extensibility Templates
We use a custom wizard to enable extensibility in templates. In order for you to create templates that use this, you'll have to add these lines to the .vstemplate file:
* Before `</TemplateContent>`:
```
<CustomParameters>
    <CustomParameter Name="$AddVsixManifestAsset$" Value="MefComponentFromSameProject" />
</CustomParameters>
```
* Before `</VSTemplate>`:
```
<WizardExtension>
    <Assembly>Microsoft.Vsix.TemplatesPackage, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</Assembly>
    <FullClassName>Microsoft.Vsix.TemplatesPackage.VsixWizard</FullClassName>
</WizardExtension>
```

`$AddVsixManifestAsset$` supports the following values:
* `MefComponentFromSameProject`
* `VsPackageFromSameProject`
* `CustomCommand`
* `CustomToolWindow`
* `ToolboxItem`
* `VsPackageWithCustomCommand` = `VsPackageFromSameProject + CustomCommand`
* `VsPackageWithCommandAndToolWindow` = `VsPackageFromSameProject + CustomCommand + CustomToolWindow`

We at Microsoft will look into simplifying this further for extensibility template authors.
### VSPackage Templates
VSPackage Templates are tougher to implement. In order to not create a package for each additional VS Package template, we've created a merging system that merges the packages into a single class.
For instance, when you add a Tool Window to a blank VSIX project, it will create a package class. If you then add a custom command, it will use the same package that the Tool Window created.

We have an example implementation of an item template in the [OptionsPageTemplate](https://github.com/Microsoft/VSSDK-Extensibility-Templates/tree/master/src/ItemTemplates/OptionsPageTemplate). 
Pay close attention to the [.vstemplate](https://github.com/Microsoft/VSSDK-Extensibility-Templates/blob/master/src/ItemTemplates/OptionsPageTemplate/OptionsPage.vstemplate) and [VsPkg.cs](https://github.com/Microsoft/VSSDK-Extensibility-Templates/blob/master/src/ItemTemplates/OptionsPageTemplate/VsPkg.cs) files. It is recommended to copy the VsPkg.cs file directly into your template project, 
to simplify things.