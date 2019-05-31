
window.onload = function () {
    
    var output = document.getElementById("txtOut");
    document.getElementById("btnIn").onclick = function (evt) {
        var marbles = document.getElementById("txtIn").value;
        document.getElementById("txtOut").value = calculateDays(marbles, txtOut);
        
    }
}

function calculateDays(marbles) {
    let vCount = 0, hrCount = 0, cycles = 0;
    let mins = [];
    let vmins = [];
    let hrs = [];
    let indicies = [];
    let twelfball = 0;
    let cycled = false;
    let results = "";

    let cycledQueue = populateArray();
    let refQueue = populateArray();
    let tempQueue = populateArray();


    while (!cycled) {

        //handles shifting 5 balls into the minute queue and tipping into the Vmin queue.
        if (vCount < 12) {
            shiftElements(mins, cycledQueue);
            //mins = arr.splice(0, 5);
            vmins.unshift(mins.shift());
            dumpMarbles(cycledQueue, mins, 4);
            vCount++;

        }
        //handles shifting balls into the hours queue and dumping the Vmin queue.
        else {
            hrs.unshift(vmins.shift());
            dumpMarbles(cycledQueue, vmins, 11);
            hrCount++;
            vCount = 0;

        }
        //dumps the hours queue and breaks the while loop.
        if (hrCount == 12) {
            twelfball = hrs.shift();
            dumpMarbles(cycledQueue, hrs, 11);
            cycledQueue.push(twelfball);
            hrCount = 0;
            cycles = 1;
            cycled = true;
        }

        //if (cycledQueue.toString() == refQueue.toString()) {
            //cycled = true;
            //return cycles / 2;
        //}
    }

    //establish the pattern of movement across one cycle of the machine
    for (var i = 0; i < marbles; i++) {
        for (var j = 0; j < marbles; j++) {
            if (refQueue[i] == cycledQueue[j]) {
                indicies[i] = j;
            }
        }
    }

    //simulates 12 hour movement using the pattern map
    while (cycledQueue.toString() !== refQueue.toString()) {
        for (var i = 0; i < marbles; i++) {
            tempQueue[indicies[i]] = cycledQueue[i]; 
        }
        cycledQueue = tempQueue.slice(0);
        cycles++;
    }

    //returns the answer
    return cycles / 2;




    //fills the min queue with elements from the base queue
    function shiftElements(arrGaining, arrLosing) {
        for (var i = 0; i < 5; i++) {
            arrGaining.unshift(arrLosing.shift());
        }
    }

    //add back in reverse order from time queue to base queue
    function dumpMarbles(arrGaining, arrLosing, number) {
        for (var i = 0; i < number; i++) {
            arrGaining.push(arrLosing.shift());
        }
    }

    //util function
    function populateArray() {
        let arr = [];
        for (var i = 0; i < marbles; i++) {
            arr[i] = i;
        }
        return arr;
    }

}


