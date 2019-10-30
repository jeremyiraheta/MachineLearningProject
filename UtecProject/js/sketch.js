let mapimg
let ar = []
let i = 0
let ttp

function preload() {
  mapimg = loadImage('https://api.mapbox.com/styles/v1/mapbox/dark-v9/static/-89.2009002,13.6998038,16,0,0/600x600?access_token=pk.eyJ1IjoiamVyZW15aXJhaGV0YSIsImEiOiJjazB4NmM0MXkwMjBzM2NvNXh3Ym82czVoIn0.UI7PImp4SkagrH_gpS5M0w')
}

function setup() {
  let canvas = createCanvas(600, 600)
  canvas.parent('sketh')
  image(mapimg, 0, 0)
}


function draw() {
  ar.forEach(e => {
    e.show()
  });
  if (ttp != undefined)
    ttp.show()
}

function mouseMoved() {
  for (const e in ar) {
    if (ar[e].hover(mouseX, mouseY)) {
      cursor(HAND)
      ttp = new Tooltip(ar[e])
      break
    } else {
      clear()
      image(mapimg, 0, 0)
      cursor(ARROW)
      ttp = undefined
    }
  }
}

function mouseClicked(fxn) {
  let isclick = false
  ar.some(e => {
    if (e.hover(mouseX, mouseY)) {
      isclick = true

      return true
    }
  });
  if (!isclick)
    append(ar, new Rest(mouseX, mouseY, 20, str(++i)))
}

class Rest {
  constructor(x, y, size, [name] = "") {
    this.x = x
    this.y = y
    this.size = size
    this.name = name
    this.img = 'data:image/png;base64,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'
  }
  show() {
    fill('red')
    ellipse(this.x, this.y, this.size, this.size)
    fill('black')
    text(this.name, this.x, this.y)
  }
  hover(x, y) {
    let d = dist(x, y, this.x, this.y)
    if (d < this.size / 2) {
      return true
    }
    return false
  }
}
class Tooltip {
  constructor(rest) {
    this.x = rest.x
    this.y = rest.y
    this.height = 200
    this.width = 200
    this.name = rest.name
    this.description = rest.description
    this.rate = rest.rate
    this.img = loadImage(rest.img)
  }
  show() {
    if (this.x + this.width > width)
      this.x = this.x - this.width
    if (this.y + this.height > height)
      this.y = this.y - this.height
    fill('gray')
    rect(this.x, this.y, this.width, this.height)
    image(this.img, this.x + 5, this.y + 5, 48, 48)
    stroke('red')
    fill('red')
    text(this.name, this.x + 5, this.y + 50, this.x + 20, this.x + 70)
  }
}