var now = new Date();
var startOfMonth = new Date(now.getFullYear(), now.getMonth(), 1);
var endOfMonth = new Date(now.getFullYear(), now.getMonth() + 1, 0);

var fifteenOfMonth = new Date(now.getFullYear(), now.getMonth(), 15);

var startTime = startOfMonth.getTime();
var endTime = endOfMonth.getTime();

var options = {
    stack: false,
    maxHeight: 640,
    horizontalScroll: true,
    verticalScroll: true,
    zoomKey: "ctrlKey",
    start: startTime,
    end: fifteenOfMonth,
    orientation: { axis: "top" },
    showCurrentTime: true,
    min: startTime,
    max: endTime,
    moveable: true,
    zoomable: true,
    showTooltips: true,
    zoomMin: 1000 * 60 * 60 * 24 * 1,
    zoomMax: 1000 * 60 * 60 * 24 * 31,
    timeAxis: {
        scale: 'weekday',
        step: 1,
    }
};

var groups = new vis.DataSet();
var items = new vis.DataSet();

var count = 10;

var indexItem = 0;

for (var i = 0; i < count; i++) {

    var start = startTime + 1000 * 60 * 60 * 24 * (1 + Math.floor(Math.random() * 7));
    var end = start + 1000 * 60 * 60 * 24 * (1 + Math.floor(Math.random() * 5));

    var start1 = start + 1000 * 60 * 60 * 24 * 4;
    var end1 = start1 + 1000 * 60 * 60 * 24 * (1 + Math.floor(Math.random() * 5));

    var start2 = start1 + 1000 * 60 * 60 * 24 * 6;
    var end2 = start2 + 1000 * 60 * 60 * 24 * (1 + Math.floor(Math.random() * 5));

    groups.add({
        id: i,
        content: `
                <div>
                    <div>MS-202402 - ${i + 10}</div>
                    <div>
                        <i class="fa-regular fa-star"></i>
                        UIL
                    </div>
                </div>
                `,
        order: i,
        className: `custom-group-timeline-${i}`
    });

    items.add({
        id: indexItem++,
        group: i,
        start: start,
        end: end,
        type: 'range',
        content: `
                    <ul>
                        <li>
                            Duy
                        </li>
                    </ul>
                `,
        className: 'todo'
    });

    items.add({
        id: indexItem++,
        group: i,
        start: start1,
        end: end1,
        type: 'range',
        content: `
                <ul>
                    <li>
                        Duy
                    </li>
                </ul>
                `,
        className: 'done'
    });

    items.add({
        id: indexItem++,
        group: i,
        start: start2,
        end: end2,
        type: 'range',
        content: `
                <ul>
                    <li>
                        Duy
                    </li>
                </ul>
                `,
        className: 'late'
    });
}

var container = document.getElementById('visualization');
var timeline = new vis.Timeline(container, null, options);
timeline.setGroups(groups);
timeline.setItems(items);

/*$('.loading-overlay').css('display', 'none')*/

function debounce(func, wait = 100) {
    let timeout;
    return function (...args) {
        clearTimeout(timeout);
        timeout = setTimeout(() => {
            func.apply(this, args);
        }, wait);
    };
}

let groupFocus = (e) => {
    let vGroups = timeline.getVisibleGroups()
    let vItems = vGroups.reduce((res, groupId) => {
        let group = timeline.itemSet.groups[groupId]
        if (group.items) {
            res = res.concat(Object.keys(group.items))
        }
        return res
    }, [])
    timeline.focus(vItems)
}

timeline.setWindow(startOfMonth, fifteenOfMonth);

timeline.on("scroll", debounce(groupFocus, 200));

setTimeout(function () {
    $('#text-loading-timeline').hide();
    $('.loading-spinner').hide();
}, 1300);