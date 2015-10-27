using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.TypescriptClientPackage
{
    public sealed class LanguageServiceTypeAttribute : MultipleBaseMetadataAttribute
    {
        public LanguageServiceTypeAttribute(string supportedExtension)
        {
            Requires.NotNullOrEmpty(supportedExtension, nameof(supportedExtension));
            _supportedExtensions = supportedExtension;
        }

        string _supportedExtensions;
        public string SupportedExtensions
        {
            get
            {
                return _supportedExtensions;
            }
        }
    }
}
