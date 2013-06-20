<h2>America's Cup Data Stream Library for .Net</h2>

<p>
This library comes from a love of sailing and the America's Cup organization's  forethought and generousity in making the race live data streaming API available to the public.  This library is my small wayof saying "thank you" to them.  In particular, I'd like to thank Ken Milnes for his patience in answeringmy dumb questions, quickly resolving small issues with the documentation and generally being very helpful.
<p>

<p>Usage of the library is extremely simple, perhaps too much so:</p>

```csharp
var x = new String("hello");
```

<pre>
<code language="c#">
    class Program
    {
    	static void Main(string[] args)
    	{
    	    var c = new Client();
    	    var e = new FeedEvents();
    	    e.OnChatterText += ch => Console.WriteLine(string.Format("{0}: {1}", 
    	    	ch.Source, ch.Text));
    	    	
    	    c.OnMessage += e.MessageHandler;
    	    c.Connect();
    	    
    	    Thread.Sleep(Timeout.Infinite);
    	}
    }
</code>
</pre>

<p>
The above program connects to the data stream server and processes messages.  When a "Chatter Text" message arrives, the OnChatterText event is triggered -- this pattern is implemented for all the messages currently available in the API (boat location, race status, etc.).  
</p>
<p>
I hope someone, somewhere finds this code useful and enjoyable.
</p>
