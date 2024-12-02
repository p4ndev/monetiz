import { getCalendars } from "expo-localization";
import 'moment/locale/pt-br';
import Moment from 'moment';

Moment.locale('pt-br');

let { calendar, timeZone, uses24hourClock } = getCalendars()[0];

uses24hourClock = true;

const utc = -3;

const useAddHours = (isoDateTime : Date, hours : number) => Moment(isoDateTime).add(hours, 'hours').toDate();
const useDateExpired = (isoDateTime : Date) => Moment(isoDateTime).isBefore(new Date());

const useShortDate = (isoDateTime) => Moment(isoDateTime).format('D/MM/YYYY');
const useShortestDate = (isoDateTime) => Moment(isoDateTime).format('DD/MM');

const useShortTime = (isoDateTime) => Moment(isoDateTime).format('H:mm:SS');
const useShortestTime = (isoDateTime) => Moment(isoDateTime).format('HH:mm');

export {
    calendar, uses24hourClock, timeZone, utc,
    useShortDate, useShortestDate, useShortTime, useShortestTime, useAddHours, useDateExpired
};