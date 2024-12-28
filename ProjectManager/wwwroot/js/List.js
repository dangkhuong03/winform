
//$(document).ready(function () {
//    updateLStatusDropdown();
//    updateLClientDropdown();
//    updateLUserDropdown();
//    updateLPICDropdown();
//    let isAscending = true;  // Biến lưu trạng thái sắp xếp (tăng dần hoặc giảm dần)
//});

document.addEventListener("DOMContentLoaded", () => {
    //console.log("DOMContentLoaded");
    const rows = document.querySelectorAll("#tableData tbody.tableContent tr");

    // Ẩn tất cả các hàng con ban đầu
    rows.forEach(row => {
        if (row.dataset.parent !== "0") {
            row.style.display = "none";
        }
    });

    // Thêm sự kiện nhấp vào hàng cha
    rows.forEach(row => {
        row.addEventListener("click", function () {
            const parentId = this.dataset.id;
            const isExpanded = this.dataset.expanded === "true";

            // Đảo trạng thái mở rộng
            this.dataset.expanded = !isExpanded;

            // Hiển thị hoặc ẩn các hàng con
            rows.forEach(childRow => {
                if (childRow.dataset.parent === parentId) {
                    if (isExpanded) {
                        findRelatedElements(parentId).forEach(childRow => {
                            childRow.style.display = "none"; // Ẩn hàng con
                            childRow.dataset.expanded = !isExpanded;
                        });
                    } else {
                        childRow.style.display = ""; // Hiển thị hàng con
                        //console.log(childRow.dataset);
                    }
                }
            });
        });
    });

});

// Hàm tìm các phần tử liên quan
function findRelatedElements(parentValue) {
    const result = [];
    const queue = [parentValue]; // Khởi tạo hàng đợi với giá trị parentValue ban đầu

    while (queue.length > 0) {
        const currentParent = queue.shift(); // Lấy giá trị đầu tiên trong hàng đợi
        // Tìm các phần tử có data-parent = currentParent
        const matchedElements = $(`tr[data-parent="${currentParent}"]`);

        // Thêm các phần tử tìm được vào kết quả
        result.push(...matchedElements);

        // Thêm data-id của các phần tử vừa tìm được vào hàng đợi
        matchedElements.each(function () {
            queue.push($(this).data("id"));
        });
    }

    return result;
}


//function toggleChildren(expanderSpan) {
//    const expanderSpan = element.querySelector('.expander'); // Select the span directly

//    if (!expanderSpan) {
//        console.error("Expander span not found in element:", element);
//        return;
//    }
//    const expandedIcon = expanderSpan.querySelector('img'); // Lấy biểu tượng bên trong span

//    if (!expandedIcon) {
//        console.error("Expanded icon not found within expander span:", expanderSpan);
//        return;
//    }

//    const parentId = element.getAttribute('data-id');
//    const childRows = document.querySelectorAll(`.child-row[data-parent-id='${parentId}']`);

//    if (expanderSpan.getAttribute('data-expanded') === "false") {
//        expandedIcon.src = "~/icon/chevron-down-24.png"; // Use relative path without "~"
//        expanderSpan.setAttribute('data-expanded', "true");
//        childRows.forEach(row => {
//            row.style.display = "flex"; // Show direct children
//        });
//    } else {
//        expandedIcon.src = "~/icon/chevron-right-24.png";
//        expanderSpan.setAttribute('data-expanded', "false");

//        // Hide all descendant rows recursively
//        hideDescendants(parentId);
//    }
//}

//function hideDescendants(parentId) {
//    const childRows = document.querySelectorAll(`.child-row[data-parent-id='${parentId}']`);

//    childRows.forEach(row => {
//        row.style.display = "none"; // Ẩn hàng
//        const expander = row.querySelector('.expander'); // Đặt lại biểu tượng và trạng thái mở rộng
//        if (expander) {
//            const expandedIcon = expander.querySelector('img');
//            expandedIcon.src = chevronRightIcon; // Sử dụng đường dẫn được tạo từ Razor
//            expander.setAttribute('data-expanded', "false");
//        }

//        // Gọi đệ quy để ẩn bất kỳ con nào của hàng này
//        const childId = row.getAttribute('data-id');
//        hideDescendants(childId);
//    });
//}

//function updateExpanderIcon(icon, expanded) {
//    icon.src = expanded ? chevronDownIcon : chevronRightIcon; // Sử dụng đường dẫn được tạo từ Razor
//}

//function resetExpander(row) {
//    const expander = row.querySelector('.expander');
//    if (expander) {
//        const icon = expander.querySelector('img');
//        icon.src = chevronRightIcon; // Sử dụng đường dẫn được tạo từ Razor
//        expander.setAttribute('data-expanded', "false");
//    }
//}