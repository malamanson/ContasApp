import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

const RelatoriosScreen = () => {
    return (
        <View style={styles.container}>
            <Text style={styles.title}>Relatórios Financeiros</Text>
            {/* Implementar gráficos ou tabelas */}
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

export default RelatoriosScreen;