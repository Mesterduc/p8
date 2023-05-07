using System;
using Animals;
using UnityEngine;
using UnityEngine.UI;

namespace Tank {
    public class DisplayAnimal : MonoBehaviour {
        public GameObject newAnimal;
        public Animal animal;
        private Vector3 animalSize;
        private AnimalState move;

        private void Start() {
            newAnimal.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(animal.animated);
            newAnimal.GetComponent<SpriteRenderer>().sortingLayerName = "foreground";
            Rigidbody2D rigid = newAnimal.AddComponent<Rigidbody2D>();
            rigid.freezeRotation = true;
            newAnimal.tag = "Fish";
            newAnimal.layer = 6;
            BoxCollider2D box = newAnimal.AddComponent<BoxCollider2D>();
            box.size = new Vector3(2, 2, 1);

            switch (animal.animalSize) {
                case AnimalSize.large:
                    animalSize = new Vector3(20 * 2, 20 * 2, 1);
                    break;
                case AnimalSize.medium:
                    animalSize = new Vector3(20 * 1.5f, 20 * 1.5f, 1);
                    break;
                case AnimalSize.Small:
                    animalSize = new Vector3(20, 20, 1);
                    break;
            }

            newAnimal.transform.localScale = animalSize;

            newAnimal.transform.position = animal.movement.currentPosition; // start position
            newAnimal.AddComponent<Animator>().runtimeAnimatorController =
                Resources.Load<RuntimeAnimatorController>(animal.animation); // animation

            move = newAnimal.AddComponent<AnimalState>();
            move.animal = animal;
        }

    }
}