// ── L-System Engine ────────────────────────────────────

// Step 1: Expand the axiom string using production rules
// For each character in the string, replace it using the rules.
// If no rule exists for a character, keep it as-is.
// Repeat for the given number of iterations.
//
// expand('F', { 'F': 'F+G', 'G': 'F-G' }, 0)  → 'F'
// expand('F', { 'F': 'F+G', 'G': 'F-G' }, 1)  → 'F+G'
// expand('F', { 'F': 'F+G', 'G': 'F-G' }, 2)  → 'F+G+F-G'
// expand('F', { 'F': 'F+G', 'G': 'F-G' }, 3)  → 'F+G+F-G+F+G-F-G'
const expand = (axiom, rules, iterations) => {


};

// Step 2: Interpret the expanded string as turtle graphics → points
// Walk the string character by character:
//   F or G = move forward (draw a line)
//   +      = turn left by angle
//   -      = turn right by angle
//   [      = save current position + angle (push to stack)
//   ]      = restore last saved position + angle (pop from stack)
//
// interpret('F', 90, 10)        → [[0,0], [10,0]]           (one line right)
// interpret('F+F', 90, 10)      → [[0,0], [10,0], [10,-10]] (right then up)
// interpret('F+F+F+F', 90, 10)  → a square
// interpret('F[-F]F', 25, 5)    → forward, branch left, continue forward
const interpret = (str, angle, lineLength, startRotation = 0) => {


};

// Step 3: Render points as an SVG polyline
// render([[0,0], [10,0], [10,10]])  → draws a polyline on the SVG
const render = (points) => {
  const svg = document.querySelector('svg');
  svg.innerHTML += `<polyline xmlns="http://www.w3.org/2000/svg"
    points="${points.join(' ')}"
    fill="none"
    stroke="black"
    stroke-width="1px" />`;
};


// ── L-System Configs ───────────────────────────────────
// Same engine, different rules. Try swapping these!

const dragonCurve = {
  axiom: 'F',
  rules: { 'F': 'F+G', 'G': 'F-G' },
  angle: 90,
  iterations: 12,
  lineLength: 5
};

const kochSnowflake = {
  axiom: 'F--F--F',
  rules: { 'F': 'F+F--F+F' },
  angle: 60,
  iterations: 4,
  lineLength: 3
};

const fractalPlant = {
  axiom: 'X',
  rules: { 'X': 'F+[[X]-X]-F[-FX]+X', 'F': 'FF' },
  angle: 25,
  iterations: 6,
  lineLength: 3,
  startRotation: -90  // point upward
};


// ── Run ────────────────────────────────────────────────
const config = dragonCurve;

const expanded = expand(config.axiom, config.rules, config.iterations);
const points = interpret(
  expanded, config.angle, config.lineLength, config.startRotation
);
render(points);
