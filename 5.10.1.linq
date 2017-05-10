<Query Kind="Statements">
  <Connection>
    <ID>6d7c1cda-083d-4f1b-b597-83dcbab19b66</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var results = from g in Genres
			  where g.Name.Equals("Heavy Metal")
			  select new
			  {
			  Genre = g.Name,
			  TracksCount = g.Tracks.Count(),
			  Tracks = from t in g.Tracks
			  		   select new
				{
					TrackName = t.Name,
					AlbumName = t.Album.Title,
					Milliseconds = t.Milliseconds,
					Size = (t.Bytes/1000) + "kb",
					Price = t.UnitPrice
				}
			  };
results.Dump("Query Math 1");