import { StyleSheet } from "react-native";

export const RoomStyle = StyleSheet.create({
    stage: {
        flex: 1,
        justifyContent: 'flex-end',
    },
    wrapper: {
        flex: 1,
        justifyContent: 'flex-end'
    },
    social: {
        marginHorizontal: 20,
        marginBottom: 10
    },
    headline: {
        fontSize: 24,
        color: 'white',
        marginHorizontal: 15,
        marginBottom: 5
    },
    summary: {
        fontSize: 19,
        color: 'white',
        marginHorizontal: 15
    },
    footer:{
        flexDirection: 'row',
        justifyContent: 'space-around',
        marginVertical: 30
    },
    label: {
        fontSize: 12,
        marginTop: 5,
        textAlign: 'center',
        textTransform: 'uppercase'
    },
    noLabel: { color: '#B90000' },
    yesLabel: { color: '#00A62E' },
    regularLabel: { color: '#FFFFFF' },
    buttonWrapper:{
        width: '25%',
        alignItems: 'center'
    },
    flag: {
        textTransform: 'uppercase',
        backgroundColor: 'yellow',
        position: 'absolute',
        paddingLeft: 10,
        paddingTop: 4,
        width: '30%',
        height: 24,
        right: 0,
        top: 40
    },
    flagContent: {
        color: '#000'
    },
    flagEnd:{
        position: 'absolute',
        marginLeft: -30,
        height: 24,
        overflow: 'hidden',
        marginTop: -4
    }
});