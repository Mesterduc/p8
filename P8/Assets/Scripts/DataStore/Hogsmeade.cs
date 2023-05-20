using Models;

namespace DataStore {
   public class Hogsmeade {
      // id skal sættes når der navigerers over til camera scene
      public static int activeTripId = -1;
      public static int nextTrip = -1;
      public static bool isPlaying;
      
      // addAnimal
      public static Journey animalJourneyInGallery;
      public static string animalImagePath;
   }
}
