using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Xml;

namespace MarketApp.Adapters
{
    internal class OfferAdapter : BaseAdapter<XmlElement>
    {
        private readonly IList<XmlElement> _offers;

        public OfferAdapter(IList<XmlElement> offers)
        {
            _offers = offers;
        }
        public override XmlElement this[int position] => _offers[position];

        public override int Count => _offers.Count;

        public override long GetItemId(int position) => long.Parse(_offers[position].Attributes["id"].Value);

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_row_layout, parent, false);
            var id = view.FindViewById<TextView>(Resource.Id.offer_id);
            id.Text = $"{GetItemId(position)}";

            return view;
        }
    }
}