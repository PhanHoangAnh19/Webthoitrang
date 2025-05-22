document.addEventListener('DOMContentLoaded', () => {
    const track = document.querySelector('.my-slider__track');
    const prev = document.querySelector('.my-slider__btn.prev');
    const next = document.querySelector('.my-slider__btn.next');
    let idx = 0;          // index hiện tại: 0 hoặc 1
    const max = 1;        // có 2 ảnh => max index = 1
    const vw = document.querySelector('.my-slider__viewport').clientWidth;

    function slide() {
        track.style.transform = `translateX(-${idx * vw}px)`;
    }

    prev.addEventListener('click', () => {
        if (idx > 0) {
            idx--;
            slide();
        }
    });
    next.addEventListener('click', () => {
        if (idx < max) {
            idx++;
            slide();
        }
    });

    // nếu muốn vòng lặp vô hạn, thay event listener thành:
    // next.addEventListener('click', () => { idx = (idx+1)%(max+1); slide(); });
    // prev tương tự.
});
