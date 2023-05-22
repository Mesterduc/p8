using Animals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

namespace Tank {
    public class AnimalStateManager : MonoBehaviour {
        public Animal animal;
        public float speed = 20;
        public float range = 10;
        public float maxDistance;
        public SpriteRenderer fishSprite;
        public Vector2 waypoint;
        private Collider2D animalClicked;
        private Rigidbody2D rigidbody2;
        private Camera camera1;
        private GameObject prefabModal;

        private void Awake() {
            // finder dyret komponenter så det ikke sker i update pga. performance
            camera1 = Camera.main;
            rigidbody2 = GetComponent<Rigidbody2D>();
            animalClicked = GetComponent<Collider2D>();
            fishSprite = GetComponent<SpriteRenderer>();
        }

        void Start() {
            // movement. tager animals movement data og sætter det ind i attributterne
            speed = animal.movement.speed;
            maxDistance = animal.movement.maxDistance;
            range = animal.movement.range;
            // flipper billedet af dyret, imod der den svømmer hen
            // og sætter en wayponit som bruges i update til at finde ud af hvor den skal svømme hen
            FlipSprite();
        }

        void Update() {
            // transform.position er dyrets/gameobjects nuværenede position.
            // Vector2.MoveTowards: tager 3 parameter hvor den er henne nu, hvor den skal hen og hvilken hastighed den skal svømme i. (time.deltatime tager højde for fps)
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            // når dyret kommer tæt nok på dens waypoint, sættes der en nyt waypoint og overordnet virker igen.
            if (Vector2.Distance(transform.position, waypoint) < range) {
                FlipSprite();
            }

            // update lytter til om man trykker på dyret
            if (Input.GetMouseButtonDown(0)) {
                // mousePosition: hvor trykker man henne
                Vector2 mousePosition = camera1.ScreenToWorldPoint(Input.mousePosition);
                // hvis mousePosition overlapper med animals Collider2D (linje 16)
                if (animalClicked.OverlapPoint(mousePosition)) {
                    //hvis animals hastighed ikke er 0 - hvis det er 0 så lukker vi modalen i stedet for
                    if (speed != 0) {
                        // stopper animal og sætter dens hastighed til 0
                        rigidbody2.constraints = RigidbodyConstraints2D.FreezePosition;
                        speed = 0;
                        // findes der andre modaler der er open slettes de
                        foreach (var oldModal in GameObject.FindGameObjectsWithTag("AnimalModal")) {
                            Destroy(oldModal);
                        }

                        // loader vores modal og sætter den tæt på animals lokation
                        GameObject prefab = Resources.Load<GameObject>("prefabs/AnimalInforModal");
                        Vector3 pos = animalClicked.transform.localPosition;
                        prefabModal = Instantiate(prefab, pos, Quaternion.identity,
                            animalClicked.transform.parent.gameObject.transform.parent);
                        // luk modal når man trykker på kryds - ved ikke hvorfor jeg har lagt den her
                        prefabModal.transform.Find("Close").transform.GetComponent<Button>().onClick
                            .AddListener(() => CloseModal());
                        // sætter navn, billede, destination og dato af dyret ind i modal
                        prefabModal.transform.Find("Name").transform.GetComponent<TMP_Text>().text = animal.name;
                        if (animal.realLifeImage != null) {
                            prefabModal.transform.Find("Image").transform.GetComponent<Image>().sprite =
                                LoadSprite(animal.getRealImage());
                        }
                        Transform infoPanel = prefabModal.transform.Find("InfoPanel");
                        infoPanel.transform.GetChild(0).transform.GetComponent<TMP_Text>().text =
                            animal.journey.destination.name;
                        infoPanel.transform.GetChild(1).transform.GetComponent<TMP_Text>().text =
                            animal.journey.GetDateTimeFormated();
                    }
                    else {
                        CloseModal();
                    }
                }
            }
            // hvis man trykker på et animal får denne animal sin hastighed/ movement tilbage - gøres ved at kigge om animals prefab er der eller ej
            if (!prefabModal) {
                rigidbody2.constraints = RigidbodyConstraints2D.FreezeRotation;
                speed = 150;
            }
        }
        
        // loader billedet - spørg hong
        private Sprite LoadSprite(string path) {
            // læser billedet og conventere det til bytes
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            // laver en texture ud af byes fra billedet
            texture.LoadImage(bytes);
            // putter en texture(vores billede) på en sprite 
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
            return sprite;
        }
        
        private void CloseModal() {
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeRotation;
            speed = 150;
            Destroy(prefabModal);
        }

        // hvis animal rammer en anden collider calles denner her: giver bare et nyt waypoint
        void OnCollisionEnter2D(Collision2D collision) {
            if (!collision.gameObject.CompareTag("Fish")) {
                waypoint = new Vector2(0, 0);
                // FlipSprite();
                Vector2 direction = waypoint - (Vector2)transform.position;
                if (direction.x < 0) {
                    fishSprite.flipX = true;
                }
                else if (direction.x >= 0) {
                    fishSprite.flipX = false;
                }
            }
        }
        
        // giver et waypoint animal skal bevæge sig hen og flipper billedet den retning den svømmer hen
        private void FlipSprite() {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),
                Random.Range(-maxDistance, maxDistance));
            Vector2 direction = waypoint - (Vector2)transform.position;
            if (direction.x < 0) {
                fishSprite.flipX = true;
            }
            else if (direction.x >= 0) {
                fishSprite.flipX = false;
            }
        }
    }
}