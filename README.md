# BorderlessWindowedFix
A Vintage Story mod to fix the borderless windowed mode in game.

## The issue
In windows specifically~

When running the game without this mod, borderless windowed mode still includes the taskbar, which is annoying.

### Why not just use fullscreen? ###
Fullscreen is not the expectation for modern games anymore. It can:
- Hamper performance.
- Prevent interaction with other programs.
- Cause crashing when alt-tabbing out.
- Prevent newer technologies such as HDR from working.

## The fix
This mod runs as you load a save or load into a server and, if you are set to borderless windowed mode, resizes the window to match the monitor resolution.

This only runs if you are in borderless windowed mode and are running Microsoft Windows.
If you do not meet the requirements, nothing is applied or changed.

## Known Issues
- Servers must also run this mod
  - This is a client-side **code** mod, so servers need to have it installed in order for you to pass the mod inspection.
  - This is due to the way the game handles mods, and is intended to prevent cheating.
- The mod only loads when you load into a save / join a server.
  - Mods are only applied once you know the mod configuration for a save or server, until then, no mods are loaded, so this fix is not applied.