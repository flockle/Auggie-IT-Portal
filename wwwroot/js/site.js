document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.faq-question').forEach(item => {
        item.addEventListener('click', () => {
            const answer = item.nextElementSibling;
            const isVisible = answer.style.display === 'block';
            // Close all other answers
            document.querySelectorAll('.faq-answer').forEach(a => a.style.display = 'none');
            // Toggle current one
            answer.style.display = isVisible ? 'none' : 'block';
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const yearSpan = document.getElementById("year");
    if (yearSpan) {
        yearSpan.textContent = new Date().getFullYear();
    }
});
