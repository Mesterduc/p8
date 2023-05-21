using Models;

namespace DataStore {
   public class Hogsmeade {
      // activeTripId: hvilken journey skal billederne sættes ind
      public static int activeTripId = -1;
      public static int nextTrip = -1;
      public static bool isPlaying;
      
      // addAnimal
      public static Journey animalJourneyInGallery;
      public static string animalImagePath;
   }
}
