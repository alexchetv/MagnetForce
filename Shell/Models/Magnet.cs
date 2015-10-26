using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using System.Xml.Linq;

namespace Shell.Models
{
    /// <summary>
    /// Magnet model which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// It represent one Magnet. Live or Dead.
    /// </summary>
    public class Magnet : ModelBase
    {
        #region Fields
            
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Magnet() { }

        #endregion

        #region Properties
        // TODO: Define your custom properties here using the modelprop code snippet

        /// <summary>
        /// Gets or sets the FEMM .ans file name.
        /// </summary>
        public string Filename
        {
            get { return GetValue<string>(FilenameProperty); }
            set { SetValue(FilenameProperty, value); }
        }
        /// <summary>
        /// Register the Filename property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FilenameProperty = RegisterProperty("Filename", typeof(string), null);

        /// <summary>
        /// Gets or sets the Name of the magnet.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), null);

        #endregion

        #region Methods

        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Name == "fool")
            {
                validationResults.Add(FieldValidationResult.CreateError(NameProperty, "Name fool not allowed"));
            }
        }

        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateBusinessRules(List<IBusinessRuleValidationResult> validationResults)
        {

        }
        #endregion
    }
}
