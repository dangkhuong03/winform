$(function () {
    $(".task-list").sortable({
        connectWith: ".task-list",
        placeholder: "ui-sortable-placeholder",
        start: function (event, ui) {
            ui.item.data("original-column", ui.item.closest(".column").data("column"));
            ui.item.addClass("dragging");
        },
        stop: function (event, ui) {
            ui.item.removeClass("dragging");

            updateCardCounts();

            const originalColumn = ui.item.data("original-column");
            const newColumn = ui.item.closest(".column").data("column");

            if (originalColumn !== newColumn) {
                ui.item.addClass("disabled");
            }

            //call ajax send to server

            //drag success, disabled still server update in database done => remove class disabled, prevent drag many time
            ui.item.removeClass("disabled");
            //ui.item.addClass("disabled");

            const taskId = ui.item.data("id");
            const newIndex = ui.item.index();

            console.log("Cập nhật thành công:", taskId, newColumn, newIndex);
        }
    }).disableSelection();

    //count card
    function updateCardCounts() {
        $(".column").each(function () {
            const cardCount = $(this).find(".task-list .task").length;
            $(this).find(".card-count").text(cardCount);
        });
    }


    //event add new card
    $(".add-card").on("click", function () {
        const column = $(this).closest(".column");
        const columnId = column.data("column");

        const cardName = prompt("New item:");
        if (!cardName) return;

        const newCard = $(`
                <div class="task" data-id="${Date.now()}">
                    <div class="d-flex justify-content-between align-items-center">
                        <div class="task-each-team">
                            <span>${cardName}</span>
                        </div>
                        <div class="piority">
                            <i class="fa-solid fa-angles-up"></i>
                        </div>
                    </div>
                    <span class="project-name d-inline-block">
                        Wisol Project
                    </span>
                    <br />
                    <span class="due-date d-inline-block">
                        <i class="fa-solid fa-calendar-days"></i> 10 OCT
                    </span>
                    <div class="d-flex justify-content-between align-items-center mt-1 pl-1">
                        <div class="wp">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                                <label class="form-check-label" for="flexCheckChecked">
                                    WP-6
                                </label>
                            </div>
                        </div>
                        <div class="user-doing">
                            <ul class="d-flex">
                                <li>Duy</li>
                            </ul>
                        </div>
                    </div>
                </div>
            `);
        column.find(".task-list").append(newCard);

        updateCardCounts();

        //call ajax to server
        console.log("Thêm thành công:", cardName);
    });

    updateCardCounts();
});