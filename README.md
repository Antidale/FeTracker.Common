# FeTracker.Common

This is a library containing some common elements of a tracker for [Free Enterprise](http://ff4fe.com/). Consumers are expected to name icons 

You can use the following table as a quick reference for how the states flow; states restart from the beginning after the last listed state. Check each individual enum for the member listing.

| Icon Type | States                    | FileName Pattern                  | Complications |
| :-------- | :-----                    | :---------------                  | :------------ |
| Boss      | Gray => Color             | `$"{bossBattle}-{state}.png";`    | None |
| Key Item  | Gray => Color => Check    | `$"{keyItem}-{state}.png";`       | None |
| Character | Gray => Color => Rejected | `$"{character}-{iconState}.png";` | Cecil and Rydia both have a more complicated pattern. See the CharacterIcon class for specific details |
| Objective | Gray => Color				| either `NotComplete.png` or `Complete.png` | In order to handle some FE forks, the Objective class has an itemCount parameter for Hunt Modes (DkMatter and Key Item) |
