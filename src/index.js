import _ from 'lodash';
import './style.scss';

function component() {

    const notesCulture = 'en';
    const notesLabels = {
        'en': [
            /*00*/['A'],
            /*01*/['A&sharp;', 'B&flat;'],
            /*02*/['B'],
            /*03*/['C'],
            /*04*/['C&sharp;', 'D&flat;'],
            /*05*/['D'],
            /*06*/['D&sharp;', 'E&flat;'],
            /*07*/['E'],
            /*08*/['F'],
            /*09*/['F&sharp;', 'G&flat;'],
            /*10*/['G'],
            /*11*/['G&sharp;', 'A&flat;'],
        ],
        'fr': [['la'], ['la&sharp;', 'si&flat;'], ['si'], ['do'], ['do&sharp;', 'ré&flat;'], ['ré'], ['ré&sharp;', 'mi&flat;'], ['mi'], ['fa'], ['fa&sharp;', 'sol&flat;'], ['sol'], ['sol&sharp;', 'la&flat;']],
    };

    let getFirst = function (obj) {
        let key = _.first(_.keys(obj));
        return obj[key];
    }

    const notesCount = getFirst(notesLabels).length;
    const stringCount = 4;
    const firstStringNote = 7;
    const fretCount = 24;
    const stringInterval = 5;
    const lang = 'en';

    let convertNote = function (noteIndex) {
        let octave = Math.trunc(noteIndex / notesCount);
        let note = noteIndex % notesCount;
        let labels = notesLabels[lang][note];
        let label = _.join(labels, ' &#183; ');
        let bastard = labels.length > 1;
        return {octave, note, label, bastard};
    };


    return _.range(stringCount)
        .map(i => firstStringNote + (i * stringInterval))
        .map(start => _.range(start, start + fretCount)
            .map(convertNote)
        );
}

console.log(component());
// document.body.appendChild(component());
