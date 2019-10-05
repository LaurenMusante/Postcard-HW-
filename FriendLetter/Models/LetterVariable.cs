namespace FriendLetter.Models //FriendLetter.Models is similar to the namespace of our main project, FriendLetter. It doesn't actually matter if the FriendLetter portion is included in both namespace names, but it's good practice to give namespaces names that clearly denote their relation to the larger app.
{
  public class LetterVariable
  {
    public string Recipient { get; set; } //so we can indicate a name of who it's going to
    public string Sender { get; set; } //so we can indicate a name of who it's from. Razoer will access this later, in order to display the inputted name on the page. 
  }
}