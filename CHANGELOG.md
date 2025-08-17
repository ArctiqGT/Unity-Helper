\# Changelog - Unity Helper



All notable changes to this project will be documented in this file.



---



\## \[1.0.0] - 2025-08-17

\### Added

\- Initial release of \*\*Unity Helper\*\* package.

\- \*\*ObjectUtilities.cs\*\*

&nbsp; - Reset Transforms: Reset position, rotation, and scale of selected GameObjects.

&nbsp; - Remove Missing Scripts: Detect and remove missing MonoBehaviour scripts from selected GameObjects.

\- \*\*BatchTools.cs\*\*

&nbsp; - Batch operations for multiple GameObjects or assets (e.g., renaming, enabling/disabling components).

\- \*\*DebugTools.cs\*\*

&nbsp; - Debug utilities for development: logging object info, checking missing references, and other helper tools.

\- Menu integration under `Arctiq`:

&nbsp; - `Arctiq -> Object Utilities`

&nbsp; - `Arctiq -> Batch Tools`

&nbsp; - `Arctiq -> Debug Tools`

\- Undo support implemented where applicable.



\### Fixed

\- N/A (initial release)



\### Notes

\- All scripts are Editor-only and must be placed inside an `Editor` folder.

\- Compatible with Unity 2021+.



