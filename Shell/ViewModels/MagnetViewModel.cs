namespace Shell.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;
    using Models;
    using Catel.Data;

    public class MagnetViewModel : ViewModelBase
    {
        public MagnetViewModel(Magnet magnet)
        {
            MagnetObject = magnet;
        }

        // TODO: Register models with the vmpropmodel codesnippet

        /// <summary>
            /// Gets or sets the property value.
            /// </summary>
        [Model]
        public Magnet MagnetObject
        {
            get { return GetValue<Magnet>(MagnetObjectProperty); }
            private set { SetValue(MagnetObjectProperty, value); }
        }

        /// <summary>
        /// Register the name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MagnetObjectProperty = RegisterProperty("MagnetObject", typeof(Magnet));
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets

        /// <summary>
            /// Gets or sets the property value.
            /// </summary>
        [ViewModelToModel("MagnetObject")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));

        /// <summary>
            /// Gets or sets the property value.
            /// </summary>
        [ViewModelToModel("MagnetObject")]
        public string Filename
        {
            get { return GetValue<string>(FilenameProperty); }
            set { SetValue(FilenameProperty, value); }
        }

        /// <summary>
        /// Register the Filename property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FilenameProperty = RegisterProperty("Filename", typeof(string));

        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
