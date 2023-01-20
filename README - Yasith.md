
Note:

1.Moved data retrieval methods to separate classes (separated Data access method to different classes under the same project)
Used Dependency Injection

2.Added methods required to display the playlists in Left Nav Bar

3. Favouite functionality for database is not implemented due to database schema is not cleared for Favourites.

4. Delete Tracks from existing playlist functionality has completed upto some extent, But couldn't complete due to "PlaylistTrack"
   Table couldn't add in to the Context model.
   Scaffolding didn't worked very well, Limitted time to investigate
   //Scaffold Command Used
   Scaffold-DbContext "DataSource=D:\Chinook\Chinook\Database\Chinook.sqlite3" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -Tables PlaylistTrack,Playlist,Track -f

5. Created New PlayList and Update New Playlist couldn't complete due to time limitation.


Thank you,
Regards,
Yasith Hettige

	