using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using MarketApp.Adapters;
using System.Text;
using MarketApp.Core.Services;

namespace MarketApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly string _url = "http://partner.market.yandex.ru/pages/help/YML.xml";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var offersList = FindViewById<ListView>(Resource.Id.offerList);

            var webService = new WebService(_url);
            var response = await webService.GetResponseResult(Encoding.GetEncoding("windows-1251"));

            var parser = new XmlParserService();
            var offers = parser.ParseDataToElements(response);

            var adapter = new OfferAdapter(offers);
            offersList.Adapter = adapter;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}