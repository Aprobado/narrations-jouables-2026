# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.6] - 2026-05-08

### Changed

- Fullscreen Blink has a fade property to blur the ellipse border

### Added

- MaterialFloatController.cs let us animate the float property of a material asset for Post Process effects.
- PlaceOnTerrain.cs is a "terrain detection" placement that triggers when entering play mode.

## [1.0.5] - 2026-04-27

### Changed

- MenuActions.cs works without defined "Menu" action in Input Asset
- ActionableItem.cs has an optional "cooldown" timer and Actions can be called at the end of that cooldown

## [1.0.4] - 2026-04-21

### Added

- Fullscreen color shader
- Fullscreen blink effect shader
- Shader with longitude and latitude as texture coordinates (for animated skyboxes)

## [1.0.3] - 2026-04-14

### Changed

- Single error message if input actions are missing from InputSystem asset to avoid error flooding.

## [1.0.2] - 2026-04-14

### Added

- Title screen template scene, prefab and scripts
- Interaction scripts and prefabs
- Highlight effect shader
- Sample scene with interaction examples

## [1.0.1] - 2026-03-31

### Changed

- Fixed version number in package.json

## [1.0.0] - 2026-03-31

### Added

- A "Super Slow Area" prefab example

### Changed

- Readme has been fixed and updated
- "Super Jump Area" example value has been exaggerated
- PlayerStatsSetter.cs can modify stats to FirstPersonController AND ThirdPersonController
- FirstPersonCamera tweaking
- Decreased mouse look sensibility

## [0.1.0] - 2026-02-16

### This is the first release of *\<Narrations Jouables 2026\>*.
