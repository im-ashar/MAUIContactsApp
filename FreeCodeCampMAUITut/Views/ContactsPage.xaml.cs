using System.Collections.ObjectModel;
using System.Globalization;
using FreeCodeCampMAUITut.Models;
using Contact = FreeCodeCampMAUITut.Models.Contact;

namespace FreeCodeCampMAUITut.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        //observable collection jb bhi update hoo gi tw woo listview ko notify kray 
        //gi khud ko update krny k liay.
        //update krny ki zarurat kue hain? kue kay listview data ki aik copy apny pass bna leta hai pehli dafa or phir
        //usi copy ko bar bar use krta data display krwany k liay issay resources bachty hain
        //tw agr data change hoo ga tw hamian listview ko btana pray ga k data ki copy ko update karo.
        //yay kaam hum ObeservableCollection say krty hain.
        base.OnAppearing();
        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }
    //jb bhi item selection change hoo gi yay call hoo ga
    //jb list load hoo gi tw kuch bhi selected nai hoo ga
    //yani null hoo ga tw
    //null say jb koi selection pr convert hoo gay tw yay call hoo ga
    //agr same item dubra select hui tw yay call nai hoo ga
    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).Id}");
        }
    }

    //jb bhi item pr tap hoo ga yay call hoo ga agr same selected item 
    //pr dubara tap kiya tw yay phir bhi call hoo ga
    //or yay hamesha ItemSelected kay bd call hoo ga
    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //kue kay isny itemselected kay bd chlna hai tw hum 
        //apni logic itemselected mai likhain gay or ismy
        //selected item ko null krdain gay ta kay
        //logic khtm honay kay bd selected item koi naa rhay 
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactsRepository.DeleteContact(contact.Id);
        //notify listView
        LoadContacts();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    /*private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }*/
}