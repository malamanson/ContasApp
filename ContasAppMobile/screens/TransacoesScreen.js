import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';

const TransacoesScreen = ({ navigation }) => {
    return (
        <View style={styles.container}>
            <Text style={styles.title}>Registrar Transações</Text>
            <TouchableOpacity
                style={styles.button}
                onPress={() => navigation.navigate('AddTransacao', { tipo: 'entrada' })}
            >
                <Text style={styles.buttonText}>Adicionar Entrada</Text>
            </TouchableOpacity>
            <TouchableOpacity
                style={styles.button}
                onPress={() => navigation.navigate('AddTransacao', { tipo: 'saida' })}
            >
                <Text style={styles.buttonText}>Adicionar Saída</Text>
            </TouchableOpacity>
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        marginBottom: 20,
    },
    button: {
        backgroundColor: '#4CAF50',
        paddingVertical: 15,
        paddingHorizontal: 30,
        borderRadius: 5,
        marginBottom: 15,
    },
    buttonText: {
        color: '#fff',
        fontSize: 16,
        fontWeight: 'bold',
    },
});

export default TransacoesScreen;
