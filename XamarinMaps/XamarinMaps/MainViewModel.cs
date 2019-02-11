using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XamarinMaps
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public MainViewModel()
		{

			//PinCollection.Add(new Pin() { Position = MyPosition, Type = PinType.Generic, Label = "I'm a Pin" });
            PinCollection.Add(new Pin() { Position = new Position(40.409264, 49.867092), Type = PinType.Generic, Label = "Baku Pin" });

            Task.Run(async () =>
			{
				var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
				MyPosition = new Position(position.Latitude, position.Longitude);
			});
		}

		

		private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
		public ObservableCollection<Pin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }

		private Position _myPosition = new Position(40.409264, 49.867092); // Baku
		public Position MyPosition { get { return _myPosition; } set { _myPosition = value; OnPropertyChanged(); } }

	}
}
