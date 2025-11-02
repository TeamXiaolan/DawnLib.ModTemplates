using Dawn;
using Dusk;

namespace DawnLib._ModTemplate.Content;

// REMOVE THIS FILE IF NOT USING DUSK
public class ExampleContentHandler : ContentHandler<ExampleContentHandler>
{
    public ExampleContentHandler(DuskMod mod) : base(mod)
    {
        RegisterContent("content bundle name here", out DefaultBundle? bundle);
    }
}