using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01.Lib
{
    public class MaisculoBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += MaisculoAction;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= MaisculoAction;
        }

        private void MaisculoAction(object sender, TextChangedEventArgs args)
        {
            if(!string.IsNullOrEmpty(args.NewTextValue)) {
                ((Entry)sender).Text = args.NewTextValue.ToUpper();
            }
        }
    }
}
