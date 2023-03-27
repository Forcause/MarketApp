using Android.Views;
using Android.Widget;
using MarketApp.Model;
using System.Collections.Generic;
using System.Xml;

namespace MarketApp.Adapters
{
    internal class OfferAdapter : BaseAdapter<Offer>
    {
        private readonly IReadOnlyList<Offer> _offers;

        public OfferAdapter(IReadOnlyList<Offer> offers)
        {
            _offers = offers;
        }
        public override Offer this[int position] => _offers[position];

        public override int Count => _offers.Count;

        public override long GetItemId(int position) => long.Parse(_offers[position].Id);

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ItemView, parent, false);
            var id = view.FindViewById<TextView>(Resource.Id.OfferId);
            id.Text = $"{GetItemId(position)}";

            return view;
        }
    }
}