# priv9-fake
Abandonware CS2 external base with a Priv9 GUI. Made it too bad by accident for me to use it anymore, so I figured that maybe someone can use parts of it (or use it as a base, somehow) to their own creations.

## What is this?
This is a (beginning, atleast) of a base I made for a CS2 cheat. It doesn't have any actual 
cheat-capabilities as of now, and I don't have motivation (or time) to finish this up.

Thus, I'll just be dumping the source code here. The code is partly super bad and chinese
(Some of it I didn't even know existed until I opened the project again, it seems I've written some of it high or something :D)
The GUI itself is a copy of Priv9 (a popular Rust external)'s GUI, but in .NET and worse. 

I couldn't actually use the Form Designer for this as the patch I did on Guna UI (that removed the annoying popups) bricked the designer for this project (don't know why), so the GUI code was written explicitly.
This has some benefits, such as no need for a form designer at some point (where features can just be added, the GUI basically builds itself!) however the implementation was fairly bad because .NET doesn't
have Generics as neat as Java, and as such some Setting types don't get built properly (and I noticed today that while I made the ToggleComponent I disregarded BoolSettings completely in favour of BindSettings!)

If you have questions, concerns or anything of the like open an issue and I'll do my best in answering them.

## Does it have anything worthwhile?
Well, a few things:
- A global keyboard hook, you can bind anything to keys and use it later! (No need for the form to be in focus or opened)
- Openable/closable overlay menu, will render on top of CS2 IF it is not in Fullscreen mode (I don't think this can be circumvented with WinForms, too bad. Also, I planned on adding dragging capabilities (not hard) but maybe I'll do that later. We'll see.)
- Self-building GUI (kind-of, this is work-in-progress, but it works somewhat well)
- Neat animations (They look cool, however the system that controls them is mid at best...)
- Watermark (This is visible in recordings, so if you want to look like you're using Priv9 for some reason eventhough you're not then you can use this for that purpose)
- As it is external and doesn't actually hook anything in the game (read/write memory) it is not VAC-detected. I planned on adding a hook hijack (as seen in MemoryUtil) but never got around to finishing it.

They aren't that complicated in the end and you could probably write them yourself given you gave the time for it but if you're lazy and don't care about code quality then this is an easy workaround.

## Credits
As displeased as I am to admit it, I wrote everything in this by myself, except some of the GUI components as they utilize Guna UI.
I think the Keyboard hook is also from somewhere, but I believe that is credited in the code.

If you use parts of this projects in your code, I'd appreciate it if you were to add a comment/credit marking somewhere in your source code crediting me. If this is not possible for some reason, I don't care for it all that much. Do what you want.
