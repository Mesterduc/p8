using System;
using Animals;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Tank {
    public class DisplayAnimal : MonoBehaviour {
        public Animal animal;
        private Vector3 animalSize;
        private AnimalStateManager move;

        private void Start() {
            this.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(animal.species.animated);
            this.GetComponent<SpriteRenderer>().sortingLayerName = "foreground";
            Rigidbody2D rigid = this.AddComponent<Rigidbody2D>();
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            this.tag = "Fish";
            this.gameObject.layer = 6;
            BoxCollider2D box = this.AddComponent<BoxCollider2D>();
            box.size = new Vector3(2, 2, 1);

            switch (animal.animalSize) {
                case AnimalSize.large:
                    animalSize = new Vector3(70, 70, 1);
                    break;
                case AnimalSize.medium:
                    animalSize = new Vector3(60, 70, 1);
                    break;
                case AnimalSize.Small:
                    animalSize = new Vector3(50, 70, 1);
                    break;
            }

            this.transform.localScale = animalSize;

            this.transform.position = animal.movement.currentPosition; // start position
            this.AddComponent<Animator>().runtimeAnimatorController =
                Resources.Load<RuntimeAnimatorController>(animal.species.animation); // animation

            move = this.AddComponent<AnimalStateManager>();
            move.animal = animal;
        }

    }
}