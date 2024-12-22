import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

const GanhosScreen = () => {
    return (
        <View style={styles.container}>
            <Text style={styles.title}>Gerenciar Ganhos</Text>
            {/* Implementar lógica para listar e adicionar ganhos */}
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
    },
});

export default GanhosScreen;
