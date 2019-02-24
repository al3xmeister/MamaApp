using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SidebarMenu : ContentView {
        public SidebarMenu() {
            InitializeComponent();  
        }
        
        public BaseViewModel ViewModel => (BaseViewModel)this.BindingContext;


        public void OnAnimationStarted(bool isPopAnimation) {
            // Put your code here but leaving empty works just fine
        }

        public void OnAnimationFinished(bool isPopAnimation) {
            // Put your code here but leaving empty works just fine
        }


        // this needs ncommented
        //public async Task NavigateIfHasNetworkAccess(Page page) {
        //    if (ViewModel.HasNetworkAccess) {
        //        await Navigation.PushAsync(page);
        //    } else {
        //        await PopupNavigation.Instance.PushAsync(new PopupView("Cannot Connect", "Please check your internet connection and try again.", "OK"));
        //    }
        //}

        private async void Muzică_Tapped(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

           // await Navigation.PushAsync(new ProfileView(ViewModel.User));

            view.IsEnabled = true;
        }

        private async void PlanAndBilling_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

          //  await NavigateIfHasNetworkAccess(new PlanAndBillingView());

            view.IsEnabled = true;
        }

        private async void ReferAndEarn_Clicked(object sender, EventArgs e) {           
            var view = (View)sender;
            view.IsEnabled = false;

            //await Navigation.PushAsync(new ReferAndEarnView());

            view.IsEnabled = true;
        }
     
        private async void FAQs_Clicked(object sender, EventArgs e) {         
            var view = (View)sender;
            view.IsEnabled = false;

           // await NavigateIfHasNetworkAccess(new BrowserView("https://venue.cheerzapp.com/faqs"));

            view.IsEnabled = true;
        }

        private async void TapGestureRecognizer_Tapped_TermsAndConditionsLink(object sender, EventArgs e) {          
            var view = (View)sender;
            view.IsEnabled = false;

           // await NavigateIfHasNetworkAccess(new BrowserView("https://venue.cheerzapp.com/termsofuse"));

            view.IsEnabled = true;
        }

        private async void TapGestureRecognizer_Tapped_PrivacyPolicyLink(object sender, EventArgs e) {          
            var view = (View)sender;
            view.IsEnabled = false;

            //await NavigateIfHasNetworkAccess(new BrowserView("https://venue.cheerzapp.com/privacypolicy"));

            view.IsEnabled = true;
        }

        private async void ContactUs_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

          //  await Navigation.PushAsync(new ContactView());

            view.IsEnabled = true;
        }

        private async void Login_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;
            
           // await Navigation.PushAsync(new LoginView());
            view.IsEnabled = true;
        }

        private async void LogSignUp_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

          //  await NavigateIfHasNetworkAccess(new SignupView());

            view.IsEnabled = true;
        }

        private void Logout_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

          //  PropertyUtility.RemoveKey("Token");
           // PropertyUtility.RemoveKey("FacebookId");
          //  PropertyUtility.SetValue("DateOfBirthPopulated","false");                       

            Device.BeginInvokeOnMainThread(async () =>
            {

            });          

            view.IsEnabled = true;
        }

        private async void PlanAndBillingView_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

         //   await Navigation.PushAsync(new PlanAndBillingView());

            view.IsEnabled = true;
        }

        private async void UpdateCardDetails_Clicked(object sender, EventArgs e) {
            var view = (View)sender;
            view.IsEnabled = false;

          //  await Navigation.PushAsync(new UpdateCardDetailsView());

            view.IsEnabled = true;
        }        
    }
}