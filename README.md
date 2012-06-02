AsyncDownloaderGUI
==================

This is a small project hacked together during a workshop on C# 5's Async.

I attended the first two days of the Progressive .NET conference 29th - 31th May 2012 at SkillsMatter in London (More info: http://skillsmatter.com/event/open-source-dot-net/prognet-2012). During the session on C# 5's new async functionality, there was a workshop segment where we collaborated to create a demo project. I hacked this project together with two colleagues.

We wanted to try out an asynchronous task that reported its progress. So this is supposed to be a fake download manager downloading a single file in multiple parts. The UI shows progress bars for each part as well as for the whole file. The whole UI is fully responsive during the download process.

The download of the file and of each part is just a single async method. We later refined the functionality so that the download could be paused and resumed.