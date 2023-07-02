namespace FreeCodeCampMAUITut.Views;

using FreeCodeCampMAUITut.Models;
using Contact = FreeCodeCampMAUITut.Models.Contact;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }
    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        //this will not work because we are passing relative path but ContactsPage is our
        // main page and we need to send absolute path and absolute path starts with //

        /*await Shell.Current.GoToAsync(nameof(ContactsPage));*/

        //instead use this because main we need to send absolute path and
        //that start with //

        /*await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");*/

        //Or you can use this
        //Navigate back to parent
        await Shell.Current.GoToAsync("..");

    }

    private void ContactControl_OnSave(object sender, EventArgs e)
    {
        var contact = new Contact
        {
            Name = contactControl.Name,
            Email = contactControl.Email,
            Phone = contactControl.Phone,
            Address = contactControl.Address
        };
        ContactsRepository.AddContact(contact);
        Shell.Current.GoToAsync("..");
    }

    private void ContactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Close");
    }
}