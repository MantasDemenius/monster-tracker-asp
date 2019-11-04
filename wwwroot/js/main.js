const hamburger = document.querySelector('.hamburger')
const navLinks = document.querySelector('.nav-links')
const collapseBtn = document.getElementsByClassName('btn-collapsible')

let state = false;

hamburger.addEventListener("click", () => {
  if (state === true) {
    navLinks.style.width = "0";
    state = false;
  } else {
    if (state === false) {
      navLinks.style.width = "45vw";
      state = true;
    }
  }
});


for (let i = 0; i < collapseBtn.length; i++) {
  collapseBtn[i].addEventListener('click', () => {
    collapseBtn[i].classList.toggle('active')
    const content = collapseBtn[i].nextElementSibling
    content.style.maxHeight ? content.style.maxHeight = null : content.style.maxHeight = content.scrollHeight + 'px'
  })
}
