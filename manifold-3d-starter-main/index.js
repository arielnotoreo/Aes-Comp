import { Manifold, CrossSection, show, color } from './lib/viewer.js';

// Your code here — build a Manifold, then call show() to display it.
// See docs.md for the full API reference.
// See demo_basics.js for examples of every feature.

const cube = Manifold.cube([20, 20, 20], true);
show(cube);
