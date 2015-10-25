using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;

namespace Shell.Models
{
    /// <summary>
        /// MFProblem model which fully supports serialization, property changed notifications,
        /// backwards compatibility and error checking.
        /// </summary>
    public class MFProblem : SavableModelBase<MFProblem>
    {
        #region Fields
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public MFProblem() { }

        #endregion

        #region Properties
        // TODO: Define your custom properties here using the modelprop code snippet

        /// <summary>
        /// Gets or sets the Problem Name.
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


        /// <summary>
        /// Gets or sets the Problem Filename.
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
        /// Gets or sets the Magnet Collection.
        /// </summary>
        public ObservableCollection<Magnet> Magnets
        {
            get { return GetValue<ObservableCollection<Magnet>>(MagnetsProperty); }
            set { SetValue(MagnetsProperty, value); }
        }

        /// <summary>
        /// Register the Magnets property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MagnetsProperty = RegisterProperty("Magnets", typeof(ObservableCollection<Magnet>), null);
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
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
