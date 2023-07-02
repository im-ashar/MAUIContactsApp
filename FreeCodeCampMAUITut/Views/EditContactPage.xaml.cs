using FreeCodeCampMAUITut.Models;
using Contact = FreeCodeCampMAUITut.Models.Contact;
namespace FreeCodeCampMAUITut.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        //Navigate back to parent
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            contact = ContactsRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                contactControl.Name = contact.Name;
                contactControl.Email = contact.Email;
                contactControl.Phone = contact.Phone;
                contactControl.Address = contact.Address;
            }
            //labelContactName.Text = contact.Name;
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = contactControl.Name;
        contact.Email = contactControl.Email;
        contact.Phone = contactControl.Phone;
        contact.Address = contactControl.Address;
        ContactsRepository.UpdateContact(contact.Id, contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Close");
    }
}