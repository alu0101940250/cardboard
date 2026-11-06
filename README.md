# Cardboard VR – Collectibles and Retriever

## setup

Scene:
- An XR player with a Main Camera and Cardboard Reticle Pointer
- A terrain created using Unity's Terrain tools
- Environment elements and objects imported from an Asset Store package (trees, rocks, bushes etc)
- Several collectible objects distributed throughout the scene (gifts)
- A special Retriever object that attracts all remaining collectibles towards the player (cylinder)

### hierarchy

Hierarchy:
- **XR:** Main player object (the movement) 
- **Head:** parent for the camera
- **Main Camera:** player's point of view
- **CardboardReticlePointer:** gaze pointer (used to interact with objects)
- **Hands:**

### layers and interactions

`Ground` layer - detects the terrain so the player only moves when he looks towards the ground

`Interactive` layer - assigned to the collectibles and Retriever. The colliders make the Cardboard Reticle Pointer detect them and send gaze interaction messages

The Cardboard Reticle Pointer has its interaction layer mask set to the `Interactive` layer.

## scripts

### playerMovement.cs

Controls the player's movement through gaze.

- Ray ray = new Ray(camera.position, camera.forward);
Makes a ray starting from the VR camera and pointing in the direction the player is looking
- Uses `Physics.Raycast()` to check if the ray hits the ground
- if(hit.collider.GetComponent<Terrain>() != null){
Checks whether the detected object contains a Unity Terrain component (is the terrain)
-                 Vector3 moveDir = camera.forward;
Calculates the horizontal movement direction (the camera's forward direction)
- Removes the vertical component and normalises the direction to maintain consistent movement speed
- Updates the XR player's position

The player moves while looking at the terrain and stops when the ray no longer hits it.

### movement.cs

Controls the behaviour of the collectibles.

-     	player = Camera.main.transform;
saves reference to the player's camera
-     	float distance = Vector3.Distance(transform.position, player.position);
Detects when the player comes close to a collectible (calculates the distance between them)
- Destroys the collectible when its close enough
- Uses `OnPointerEnter()` and `OnPointerExit()` for gaze interaction feedback
- `AttractToPlayer()` method - activates the collectible's movement towards the player
- `Vector3.MoveTowards()` - moves the collectible towards the player's camera.

### retrieve.cs

Controls the Retriever object.

- `OnPointerEnter()`- is called when the player looks at the Retriever
-     	movement[] allCollectibles = FindObjectsOfType<movement>();
Uses `FindObjectsOfType<movement>()` to find all active objects that have the collectible movement script.
- Iterates through the collected objects using a `foreach` loop
- Calls `AttractToPlayer()` on every collectible to make them move towards the player
- Implements `OnPointerExit()` to receive the gaze exit event

The Retriever therefore allows the player to attract all remaining collectibles simply by looking at it.

### CardboardStartup.cs

Initialises the Google Cardboard XR functionality.

From exercise directions added:

```csharp
#if !UNITY_EDITOR
    Api.UpdateScreenParams();
#endif
```

## 4. build Configuration

The project was configured with:
- Platform: Android.
- XR Plugin: Google Cardboard.
- Scripting Backend: IL2CPP.
- Target Architecture: ARM64.
- Graphics API: OpenGLES3.
- Active Input Handling: Input System Package (New).


# Español

# Cardboard VR – Collectibles and Retriever

## configuración

Escena:
- Un jugador XR con una Main Camera y un Cardboard Reticle Pointer.
- Un terreno creado utilizando las herramientas Terrain de Unity.
- Elementos del entorno y objetos importados desde un paquete de la Asset Store (árboles, rocas, arbustos, etc.).
- Varios objetos coleccionables distribuidos por la escena (regalos).
- Un objeto especial Retriever que atrae todos los objetos coleccionables restantes hacia el jugador (cilindro).

### jerarquía

Jerarquía:
- **XR:** Objeto principal del jugador (contiene el movimiento).
- **Head:** objeto padre de la cámara.
- **Main Camera:** punto de vista del jugador.
- **CardboardReticlePointer:** puntero de mirada (utilizado para interactuar con los objetos).
- **Hands:** manos.

### capas e interacciones

`Ground` layer: detecta el terreno para que el jugador solo se mueva cuando mira hacia el suelo.

`Interactive` layer: asignada a los objetos coleccionables y al Retriever. Los colliders permiten que el Cardboard Reticle Pointer los detecte y envíe mensajes de interacción mediante la mirada.

La máscara de capas de interacción del Cardboard Reticle Pointer está configurada para detectar la capa `Interactive`.

## scripts

### playerMovement.cs

Controla el movimiento del jugador mediante la mirada.

- `Ray ray = new Ray(camera.position, camera.forward);`  
  Crea un rayo que parte de la cámara VR y apunta en la dirección hacia la que mira el jugador.
- Utiliza `Physics.Raycast()` para comprobar si el rayo alcanza el suelo.
- `if(hit.collider.GetComponent<Terrain>() != null){`  
  Comprueba si el objeto detectado contiene un componente Unity Terrain (es decir, si es el terreno).
- `Vector3 moveDir = camera.forward;`  
  Calcula la dirección horizontal del movimiento a partir de la dirección frontal de la cámara.
- Elimina el componente vertical y normaliza la dirección para mantener una velocidad de movimiento constante.
- Actualiza la posición del objeto XR del jugador.

El jugador se mueve mientras mira al terreno y se detiene cuando el rayo deja de detectarlo.

### movement.cs

Controla el comportamiento de los objetos coleccionables.

- `player = Camera.main.transform;`  
  Guarda una referencia a la cámara del jugador.
- `float distance = Vector3.Distance(transform.position, player.position);`  
  Detecta cuándo el jugador se acerca a un objeto coleccionable (calcula la distancia entre ambos).
- Destruye el objeto coleccionable cuando está suficientemente cerca.
- Utiliza `OnPointerEnter()` y `OnPointerExit()` para proporcionar información sobre las interacciones mediante la mirada.
- Método `AttractToPlayer()`: activa el movimiento del objeto coleccionable hacia el jugador.
- `Vector3.MoveTowards()`: mueve el objeto coleccionable hacia la cámara del jugador.

### retrieve.cs

Controla el objeto Retriever.

- `OnPointerEnter()`: se llama cuando el jugador mira directamente al Retriever.
- `movement[] allCollectibles = FindObjectsOfType<movement>();`  
  Utiliza `FindObjectsOfType<movement>()` para encontrar todos los objetos activos que tienen asociado el script de movimiento de los coleccionables.
- Recorre los objetos encontrados mediante un bucle `foreach`.
- Llama a `AttractToPlayer()` en cada objeto coleccionable para hacer que se mueva hacia el jugador.
- Implementa `OnPointerExit()` para recibir el evento que indica que el jugador ha dejado de mirar al objeto.

Por tanto, el Retriever permite al jugador atraer todos los objetos coleccionables restantes simplemente mirándolo.

### CardboardStartup.cs

Inicializa la funcionalidad Google Cardboard XR.

Siguiendo las instrucciones de la práctica, se añadió:

```csharp
#if !UNITY_EDITOR
    Api.UpdateScreenParams();
#endif
```

## 4. configuración de compilación

El proyecto se configuró con:
- Plataforma: Android.
- XR Plugin: Google Cardboard.
- Backend de scripting: IL2CPP.
- Arquitectura de destino: ARM64.
- API gráfica: OpenGLES3.
- Gestión de entradas activa: Input System Package (New).
