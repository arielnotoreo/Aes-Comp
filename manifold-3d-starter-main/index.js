import { Manifold, show, color } from './lib/viewer.js';

// Create a single diamond-shaped petal
const makePetal = (size) => {
  return Manifold.cube([size, size, size * 0.2], true)
    .rotate([0, 0, 45]); // rotate square into diamond
};

// recursive flower
const flower = (size, depth) => {

  // Base case: small center core
  if (depth <= 0) {
    return Manifold.sphere(size * 0.3, 24);
  }

  const petals = [];
  const count = 6; // number of petals per layer

  for (let i = 0; i < count; i++) {
    const angle = (360 / count) * i;

    const petal = makePetal(size)
      .translate([size, 0, 0])   // move outward from center
      .rotate([0, 0, angle]);    // rotate into circular arrangement

    petals.push(petal);
  }

  // recursive inner flowers
  const inner = flower(size * 0.5, depth - 1);

  // combine
  return Manifold.union([
    ...petals,
    inner
  ]);
};

// Build the model
const model = flower(20, 4);

// Show it
show(model, color(0.8, 0.3, 0.6));