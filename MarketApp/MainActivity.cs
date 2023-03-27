using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using MarketApp.Adapters;
using MarketApp.Interfaces;
using MarketApp.Model;
using MarketApp.Services;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MarketApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private IOfferSource _offerSource;
        private IReadOnlyList<Offer> _offers;
        private string _uri;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var mainView = FindViewById<ListView>(Resource.Id.MainView);

            mainView.ItemClick += OnItemClicked;

            var settings = Assets.Open("config.xml");
            _uri = XDocument.Load(settings).Root.Value;
            _offerSource = new YmlCatalogOfferSource(_uri);
            _offers = await _offerSource.GetOffers();
            var adapter = new OfferAdapter(_offers);
            mainView.Adapter = adapter;

        }

        private void OnItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(OfferActivity));
            var offerToSend = JsonConvert.SerializeObject(_offers[e.Position]);

            intent.PutExtra("Offer", offerToSend);
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}