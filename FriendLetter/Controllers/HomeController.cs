using Microsoft.AspNetCore.Mvc; //gives us acess to ASP.NET's built-in Controller class.
using FriendLetter.Models; // make our model available to our controller.
namespace FriendLetter.Controllers
{
  public class HomeController : Controller //By adding : Controller to our HomeController class, we tell .NET that HomeController should inherit or extend functionality from ASP.NET Core's built-in Controller class
  { 
    // public string Hello() { return "Hello friend!"; } // this method is a route, it will create a special path, or pattern, in our application. If we revisit our Home() method, we see it returns the string "Hello friend!". This is called the action, because it defines what the site will do when a client requests this particular path.

    // public string Goodbye() { return "Goodbye friend."; }

    //the above, refactored using ROUTE DECORATORS ([Route("/hello)]): 
    [Route("/hello")]
    public string Hello() { return "Hello friend!"; }

    [Route("/goodbye")]
    public string Goodbye() { return "Goodbye friend."; }

    [Route("/")]
    public ActionResult Letter() { return View(); }

    [Route("/form")]
    public ActionResult Form() { return View(); }

    [Route("/postcard")]
    public ActionResult Postcard(string recipient, string sender) //Here we create a new Postcard() route. This time, the route's method takes arguments: a string for both recipient and sender. Because we told our <form> in Form.cshtml to have an action="/postcard", the route matching the /postcard path is automatically invoked. That's our Postcard() route. Our form has two <input>s, one with a name="sender" attribute and another with a name="recipient" attribute. These are the parameters we pass into the route method.  ALL CAPS : Note that our application is looking for name attributes, not the id or anything else. These must match the parameters we pass into the route method. This must be an exact match or it will not work.

    {
    LetterVariable myLetterVariable = new LetterVariable();
    myLetterVariable.Recipient = recipient;
    myLetterVariable.Sender = sender;
    return View(myLetterVariable); //this was added after putting HTML into Postcard.html
    }
        
        //The return type of our Letter() method is now an ActionResult, not a string. This is a built-in MVC class that handles rendering views.
        //Our method returns another method called View(). This is a built-in method from the Microsoft.AspNetCore.Mvc namespace. When our route is invoked, it will return a view.

        LetterVariable myLetterVariable = new LetterVariable();
        myLetterVariable.Recipient = "Lina";
        myLetterVariable.Sender = "Jasmine";
        return View(myLetterVariable); //Our Letter() route creates a new variable of type LetterVariable, saves a name in its Recipient property, and then passes the variable into the view. This ensures our corresponding Letter.cshtml view now has access to our LetterVariable object.
  }
}
// Because instances of @Model in the view represent the argument we've passed into the View() method, @Model.Recipient is the same as calling myLetterVariable.Recipient.

//When a client like a web browser makes a request to our server, it must include the URL it's requesting. In the example above, the URL contains a /home/hello path.

// Our server looks at the HomeController because it matches the first /home portion of the URL path.

// In order to find the more specific /home/hello data, our server looks for a Hello() method in the HomeController.

// The server provides our client with a response. In this case, our Hello() method returns the string "Hello friend!".

// Our client receives the response and renders the resources in the browser. We see "Hello friend!" appear on the page.

