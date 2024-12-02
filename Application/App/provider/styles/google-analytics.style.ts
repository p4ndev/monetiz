import { StyleSheet } from 'react-native';

export const GAStyle = StyleSheet.create({
    stage: {
        backgroundColor: 'rgba(0,0,0,0.8)',
        position: 'absolute',
        width: '100%',
        paddingHorizontal: 10,
        paddingTop: 15,
        height: 110,
        bottom: 0,
    },
    instructions: {
        color: 'white',
        fontSize: 15,
        textAlign: 'center'
    },
    grid: {
        flexDirection: 'row',
        marginTop: 5
    },
    cell: {
        flex: 0.5,
        transform: 'scale(0.85)'
    },
});