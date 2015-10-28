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
            RemoveMagnet = new Command(OnRemoveMagnetExecuteAsync);
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

        /// <summary>
            /// Gets or sets the property value.
            /// </summary>
        [ViewModelToModel("MagnetObject")]
        public bool Included
        {
            get { return GetValue<bool>(IncludedProperty); }
            set { SetValue(IncludedProperty, value); }
        }

        /// <summary>
        /// Register the Included property so it is known in the class.
        /// </summary>
        public static readonly PropertyData IncludedProperty = RegisterProperty("Included", typeof(bool));

        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        public Command RemoveMagnet { get; private set; }

        private void OnRemoveMagnetExecuteAsync()
        {
            // TODO: Handle command logic here
        }

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
