using Animals;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

namespace Tank {
    public class AnimalState : MonoBehaviour {
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
            camera1 = Camera.main;
            rigidbody2 = GetComponent<Rigidbody2D>();
            animalClicked = GetComponent<Collider2D>();
            fishSprite = GetComponent<SpriteRenderer>();
        }

        void Start() {
            // prefab = Resources.Load<GameObject>("prefabs/AnimalInforModal");
            
            
            speed = animal.movement.speed;
            maxDistance = animal.movement.maxDistance;
            range = animal.movement.range;
            FlipSprite();
        }

        void Update() {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < range) {
                FlipSprite();
            }

            if (Input.GetMouseButtonDown(0)) {
                Vector2 mousePosition = camera1.ScreenToWorldPoint(Input.mousePosition);
                if (animalClicked.OverlapPoint(mousePosition)) {
                    if (speed != 0) {
                        rigidbody2.constraints = RigidbodyConstraints2D.FreezePosition;
                        speed = 0;
                        GameObject prefab = Resources.Load<GameObject>("prefabs/AnimalInforModal");
                        Vector3 pos = animalClicked.transform.localPosition;
                        foreach (var oldModal in GameObject.FindGameObjectsWithTag("AnimalModal")) {
                            Destroy(oldModal);
                        }
                        
                        prefabModal = Instantiate(prefab, pos, Quaternion.identity, animalClicked.transform.parent.gameObject.transform.parent);
                        prefabModal.transform.Find("Close").transform.GetComponent<Button>().onClick.AddListener(() => CloseModal());
                        prefabModal.transform.Find("Name").transform.GetComponent<TMP_Text>().text = animal.name;
                        // prefabModal.transform.Find("Image").transform.GetComponent<Image>().sprite = Resources.Load<Image>(animal.realLifeImage));
                        Transform infoPanel = prefabModal.transform.Find("InfoPanel");
                        infoPanel.transform.GetChild(0).transform.GetComponent<TMP_Text>().text = animal.journey.destination.name;
                        infoPanel.transform.GetChild(1).transform.GetComponent<TMP_Text>().text = animal.journey.GetDateTimeFormated();
                        
                    }
                    else {
                        CloseModal();
                    }
                }
            }

            if (!prefabModal) {
                rigidbody2.constraints = RigidbodyConstraints2D.FreezeRotation;
                speed = 150;
            }
        }

        private void CloseModal() {
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeRotation;
            speed = 150;
            Destroy(prefabModal);
        }
        

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