/*******************************************************************************
 |                               ***Globant***
 |
 |Classe    : ContratoCtrl.cls
 |Data      : 27/11/2020
 |Descrição : Classe de controller para o component Contrato.cmp
 |Autor     : Willyan Marques
 |
 ********************************************************************************/

public without sharing class ContratoCtrl {

    private static final String RECORD_TYPE_OPORTUNIDADE_CONTRATO = Schema.SObjectType.Opportunity.getRecordTypeInfosByDeveloperName().get('Contrato').getRecordTypeId();
    private static final String RECORD_TYPE_VERBA_CONTRATO = Schema.SObjectType.BusinessPlanBudget__c.getRecordTypeInfosByDeveloperName().get('LongDurationContract').getRecordTypeId();
    private static final String RECORD_TYPE_CONTRATO_LONGO_PRAZO = Schema.SObjectType.Contract.getRecordTypeInfosByDeveloperName().get('ContratoLongoPrazo').getRecordTypeId();

     /*******************************************************************************
	 |Método    : salvarOneracao
	 |Data      : 25/01/2021
	 |Descrição : Atualiza os campos de oneração para uma determinada verba
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> salvarOneracao(String dadosOneracao){
        Map<String, Object> response = new Map<String, Object>();
        try {
            if(checkCustomPermission('ContratoLongoPrazoOneracaoVerba')){
                Map<String, String> item = (Map<String, String>) JSON.deserialize(dadosOneracao, Map<String, String>.class);
                BusinessPlanBudget__c verba = new BusinessPlanBudget__c();
                Boolean oneracao = Boolean.valueOf(item.get('oneracao'));
                verba.Id = item.get('idVerba');
                verba.Oneracao__c = oneracao;
                verba.Abrangencia_da_oneracao__c = oneracao ? item.get('abrangencia') : null;
                verba.ClienteOneracao__c = oneracao ? item.get('cliente') : '';
                verba.Onera_o_porc__c = oneracao ? Double.valueOf(item.get('percentual')) : 0;
                verba.Oneracao_Valida_Desde__c = oneracao ? Date.valueOf(item.get('validadeDesde')) : null;
                verba.Oneracao_Valida_ate__c = oneracao ? Date.valueOf(item.get('validadeAte')) : null;
                Database.SaveResult result = Database.update(verba, false);
                String mensagemErro;
                if (!result.isSuccess()) {
                    for (Database.Error err : result.getErrors()) {
                         mensagemErro = err.getMessage();
                         break;
                    }
                }
                response.put('sucesso', result.isSuccess() ? true : false);
                response.put('mensagemErro', result.isSuccess() ? 'Oneração da verba atualizada com sucesso!' : mensagemErro);
            } else {
                response.put('sucesso', false);
                response.put('mensagemErro', 'Ops! Você não tem permissão para realizar a oneração da verba.');
            }
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());
        }
        return response;
    }
    
    /*******************************************************************************
	 |Método    : carregarVerbasPorOppId
	 |Data      : 20/01/2021
	 |Descrição : Retorna uma lista com todas as verbas por oportunidade
	 ********************************************************************************/
    
    @AuraEnabled
    public static Map<String, Object> carregarVerbasPorOppId(String oppId){
        Map<String, Object> response = new Map<String, Object>();
        try {
            VerbaModel verba;
            List<VerbaModel> lista = new List<VerbaModel>();
            List<BusinessPlanBudget__c> verbas = [SELECT 
                                                    Id, 
                                                    Name,
                                                    BudgetType__c,
                                                    BusinessPlan__c,
                                                    BusinessPlan__r.AccountId,
                                                    BusinessPlan__r.BusinessPlanCoverage__c,
                                                    Abrangencia__c,
                                                    Cliente__c,
                                                    Unidade__c,
                                                    Montante__c,
                                                    Forma_de_pagamento__c,
                                                    Periodicidade__c,
                                                    ValidityStartDate__c,
                                                    ValidityFinalDate__c,
                                                    BudgetType__r.Name,
                                                    Oneracao__c,
                                                    Abrangencia_da_oneracao__c,
                                                    Onera_o_porc__c,
                                                    Oneracao_Valida_Desde__c,
                                                    Oneracao_Valida_ate__c,
                                                    ClienteOneracao__c
                                                FROM 
                                                    BusinessPlanBudget__c 
                                                WHERE 
                                                    BusinessPlan__c =: oppId 
                                                    AND RecordTypeId =: RECORD_TYPE_VERBA_CONTRATO];
            for(BusinessPlanBudget__c v: verbas) {
                verba = new VerbaModel();
                verba.idVerba = v.Id;
                verba.descVerba = v.Name;
                verba.idTipoVerba = v.BudgetType__c;
                verba.descTipoVerba = v.BudgetType__r.Name;
                verba.valueAbrangenciaVerba = v.Abrangencia__c;
                verba.descAbrangenciaVerba = v.Abrangencia__c;
                verba.descClienteOneracao = v.ClienteOneracao__c;
                verba.nomeClienteVerba = v.Cliente__c;
                verba.montante = v.Montante__c;
                verba.unidade = v.Unidade__c;
                verba.formaPagamento = v.Forma_de_pagamento__c;
                verba.periodicidade = v.Periodicidade__c;
                verba.verbaValidadeDesde = String.valueOf(v.ValidityStartDate__c);
                verba.verbaValidadeAte = String.valueOf(v.ValidityFinalDate__c);
                verba.oneracao = v.Oneracao__c;
                verba.abrangenciaOneracao = v.Abrangencia_da_oneracao__c;
                verba.percentualOneracao = String.valueOf(v.Onera_o_porc__c != null ? v.Onera_o_porc__c : 0);
                verba.oneracaoValidaDesde = String.valueOf(v.Oneracao_Valida_Desde__c);
                verba.oneracaoValidaAte = String.valueOf(v.Oneracao_Valida_ate__c);
                lista.add(verba);
            }

            Map<String, String> mapaAbrangenciaContrato = new Map<String, String>();
            for(PickListModel p: picklistAbrangenciaContrato()){
                mapaAbrangenciaContrato.put(p.value, p.label);
            }

            response.put('sucesso', lista.size() > 0 ? true : false);
            response.put('mensagemErro', lista.size() > 0 ? 'Sucesso!' : 'Nenhuma verba encontrada para esta oportunidade!');
            response.put('abrangenciaContrato', verbas.size() > 0 ? mapaAbrangenciaContrato.get(verbas[0].BusinessPlan__r.BusinessPlanCoverage__c) : '');
            response.put('idConta', verbas.size() > 0 ? verbas[0].BusinessPlan__r.AccountId : '');
            response.put('verbas', lista);
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());
        }
        return response;
    }
    
    /*******************************************************************************
	 |Método    : carregarDadosContatoSalvo
	 |Data      : 17/12/2020
	 |Descrição : Retorna todos os dados necessários para preenchimento do contrato 
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> carregarDadosContatoSalvo(String accountId, String oppId){
        System.debug('ContratoCtrl >>> carregarDadosContatoSalvo');
        Map<String, Object> response = new Map<String, Object>();
        try {
            Opportunity opp = [
                SELECT 
                    Name, 
                    Denominacao__c,
                    BusinessPlanStartDate__c,
                    BusinessPlanEndDate__c,
                    BusinessPlanCoverage__c,
                    Renovacao_automatica__c,
                    NovoContrato__c,
                    Inclui_PIS__c,
                    Inclui_IPI__c,
                    Inclui_COFINS__c,
                    Inclui_ICMS__c,
                    Inclui_ICMS_ST__c,
                    Description
                FROM 
                    Opportunity
                WHERE 
                    Id =: oppId 
                    AND AccountId =: accountId 
                    AND RecordTypeId =: RECORD_TYPE_OPORTUNIDADE_CONTRATO
            ];
            List<BusinessPlanBudget__c> verbas = [
                SELECT
                    Id,
                    BudgetType__c, //id tipo verba
                    BudgetType__r.Name, //descricao da verba
                    BusinessPlan__c,
                    Abrangencia__c,
                    Cliente__c,
                    Unidade__c,
                    Montante__c,
                    Forma_de_pagamento__c,
                    Periodicidade__c,
                    ValidityStartDate__c,
                    ValidityFinalDate__c
                FROM 
                    BusinessPlanBudget__c 
                WHERE
                    BusinessPlan__c =: oppId
                    AND RecordTypeId =: RECORD_TYPE_VERBA_CONTRATO
            ];
            //dados da oportunidade
            response.put('sucesso', true);
            //dados cabecalho
            response.put('name', opp.Name);
            response.put('denominacao', opp.Denominacao__c);
            response.put('dataInicioContrato', opp.BusinessPlanStartDate__c);
            response.put('dataTerminoContrato', opp.BusinessPlanEndDate__c);
            response.put('abrangenciaContrato', opp.BusinessPlanCoverage__c);
            response.put('renovacaoAutomatica', opp.Renovacao_automatica__c);
            response.put('tipoContrato', opp.NovoContrato__c);
            //dados base de calculo
            response.put('pis', opp.Inclui_PIS__c);
            response.put('ipi', opp.Inclui_IPI__c);
            response.put('cofins', opp.Inclui_COFINS__c);
            response.put('icms', opp.Inclui_ICMS__c);
            response.put('icmsst', opp.Inclui_ICMS_ST__c);
            //observacoes
            response.put('observacoes', opp.Description);

            //dados da verba
            List<VerbaModel> verbasSalvas = new List<VerbaModel>();
            List<DetalheVerbaModel> detalheSalvos = new List<DetalheVerbaModel>();
            if(verbas.size() > 0){
                VerbaModel item;
                for(BusinessPlanBudget__c v: verbas){
                    item = new VerbaModel();
                    item.idVerba = v.Id;
                    item.idTipoVerba = v.BudgetType__c;
                    item.descTipoVerba = v.BudgetType__r.Name;
                    item.valueAbrangenciaVerba = v.Abrangencia__c;
                    item.descAbrangenciaVerba = v.Abrangencia__c;
                    item.nomeClienteVerba = v.Cliente__c;
                    item.montante = v.Montante__c;
                    item.unidade = v.Unidade__c;
                    item.formaPagamento = v.Forma_de_pagamento__c;
                    item.periodicidade = v.Periodicidade__c;
                    item.verbaValidadeDesde = String.valueOf(v.ValidityStartDate__c);
                    item.verbaValidadeAte = String.valueOf(v.ValidityFinalDate__c);
                    verbasSalvas.add(item);
                }
                DetalheVerbaModel detalhe;
                for(BusinessPlanBudgetDetail__c det: [ 
                    SELECT 
                    Id, StoreQuantity__c, BusinessPlanBudget__c,
                    Participacao__c, Familia__c, ExtraPointType__c, BusinessPlanBudget__r.BudgetType__r.Name,
                    Quantidade_de_Familia__c, NumberPhotos__c, 
                    Period__c, Family__c, Quantidade_de_Pontos__c
                    FROM BusinessPlanBudgetDetail__c 
                    WHERE BusinessPlanBudget__c  IN: verbas ]){

                    detalhe = new DetalheVerbaModel();
                    detalhe.idDetalhe = det.Id;
                    detalhe.verbaId = det.BusinessPlanBudget__c;
                    detalhe.qtdPontos = String.valueOf(det.Quantidade_de_Pontos__c);
                    detalhe.qtdLojas = String.valueOf(det.StoreQuantity__c);
                    detalhe.qtdFamilias = String.valueOf(det.Quantidade_de_Familia__c);
                    detalhe.qtdFotos = String.valueOf(det.NumberPhotos__c);
                    detalhe.percentParticipacao = String.valueOf(det.Participacao__c);
                    detalhe.periodo = det.Period__c;
                    detalhe.descFamilia = det.Familia__c;
                    detalhe.descTipoVerba = det.BusinessPlanBudget__r.BudgetType__r.Name;
                    detalhe.descTipoDetalhe = det.ExtraPointType__c;
                    detalheSalvos.add(detalhe);
                }

            }
			String idContratoAnterior = [SELECT Id FROM Contract WHERE AccountId =: accountId ORDER BY CreatedDate DESC LIMIT 1]?.Id;
            /*List<Contract> contratosAnteriores = [SELECT Id, Name, Status, Account.Name, Account.SAPCode__c, Description FROM Contract WHERE AccountId =: accountId ORDER BY CreatedDate DESC];
            List<ContratoAnteriorModel> contAnteriores = new List<ContratoAnteriorModel>();
            for(Contract cont : contratosAnteriores){
                ContratoAnteriorModel contratoAnt = new ContratoAnteriorModel();
                contratoAnt.idContrato = cont.id;
                contratoAnt.codCliente = cont.Account.SAPCode__c;
                contratoAnt.descContrato = cont.Description;
                contratoAnt.nomeCliente =  cont.Account.Name;
                contratoAnt.linkContratoLabel = 'Link';
                contratoAnt.linkContrato = '/' + cont.id;
                contAnteriores.add(contratoAnt);
            }

            response.put('contratosAnteriores', contAnteriores);*/

            response.put('idContratoAnterior', String.isNotBlank(idContratoAnterior) ? idContratoAnterior : '');

            response.put('detalhes', detalheSalvos.size() > 0 ? detalheSalvos : new List<DetalheVerbaModel>());
            response.put('verbas', verbasSalvas.size() > 0 ? verbasSalvas : new List<VerbaModel>());

        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', 'Falha ao carregar dados do contrato salvo! ' + e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : carregarIdContaPorOppId
	 |Data      : 16/12/2020
	 |Descrição : Retorna o id da conta vinculada a oportunidade de contrato
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> carregarIdContaPorOppId(String oppId){
        System.debug('ContratoCtrl >>> carregarIdContaPorOppId');
        Map<String, Object> response = new Map<String, Object>();
        try {
            String accountId = [SELECT AccountId FROM Opportunity WHERE Id =: oppId AND RecordTypeId =: RECORD_TYPE_OPORTUNIDADE_CONTRATO]?.AccountId;
            response.put('accountId', accountId);
            response.put('sucesso', String.isNotBlank(accountId) ? true : false);
            response.put('mensagemErro', String.isNotBlank(accountId) ? 'Sucesso!' : 'Falha ao localizar id da conta para esta oportunidade.');
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : carregarCabecalho
	 |Data      : 27/11/2020
	 |Descrição : Retorna os dados para preenchimento do cabeçalho do contrato
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> carregarCabecalho(String accountId){
        System.debug('ContratoCtrl >>> carregarCabecalho');
        Map<String, Object> response = new Map<String, Object>();
        try {
            List<Account> conta = [SELECT
                            Name,
                            GrandesContas__c,
                            Matriz__c,
                            MatrizSAPCodeText__c,
                            MatrizSAPCode__c,
                            SAPCode__c, //Cod. Cliente
                            CNPJ__c,
                            Bandeira__c,
                            Polo__c,
                            BillingAddress, //Objeto JSON,
                            BillingNeighborhood__c //Bairro
                            FROM Account 
                            WHERE Id =: accountId
                            AND Status__c = 'Ativo'];
            if(conta.size() > 0){
                Map<String, String> endereco = (Map<String, String>) JSON.deserialize(JSON.serialize(conta[0].BillingAddress), Map<String, String>.class);
                response.put('sucesso', true);
                response.put('nome', conta[0].Name);
                response.put('cnpj', conta[0].CNPJ__c);
                response.put('codMatriz', conta[0].MatrizSAPCodeText__c);
                response.put('bandeira', conta[0].Bandeira__c);
                response.put('polo', conta[0].Polo__c);
                response.put('descMatriz', conta[0].Matriz__c);
                response.put('codCliente', conta[0].SAPCode__c);
                response.put('grandeConta', conta[0].GrandesContas__c);
                response.put('rua', endereco.get('street'));
                response.put('cidade', endereco.get('city'));
                response.put('uf', endereco.get('state'));
                response.put('bairro', conta[0].BillingNeighborhood__c);
                String idContratoAnterior = [SELECT Id FROM Contract WHERE AccountId =: accountId ORDER BY CreatedDate DESC LIMIT 1]?.Id;
                response.put('idContratoAnterior', String.isNotBlank(idContratoAnterior) ? idContratoAnterior : '');
                /*List<Contract> contratosAnteriores = [SELECT Id, Name, Status, Account.Name, Account.SAPCode__c, Description FROM Contract WHERE AccountId =: accountId ORDER BY CreatedDate DESC];
                List<ContratoAnteriorModel> contAnteriores = new List<ContratoAnteriorModel>();
                for(Contract cont : contratosAnteriores){
                    ContratoAnteriorModel contratoAnt = new ContratoAnteriorModel();
                    contratoAnt.idContrato = cont.id;
                    contratoAnt.codCliente = cont.Account.SAPCode__c;
                    contratoAnt.descContrato = cont.Description;
                    contratoAnt.nomeCliente =  cont.Account.Name;
                    contratoAnt.linkContratoLabel = 'Link';
                    contratoAnt.linkContrato = '/' + cont.id;
                    contAnteriores.add(contratoAnt);
                }

                response.put('contratosAnteriores', contAnteriores);*/
            } else {
                response.put('sucesso', false);
                response.put('mensagemErro', 'Falha ao carregar cabeçalho do contrato! Por favor, verifique se o status da conta está "Ativo".');
            }
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', 'Falha ao carregar cabeçalho do contrato! ' + e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : carregarClienteVerba
	 |Data      : 22/12/2020
	 |Descrição : Retorna as contas para o picklist de cliente da verba de acordo com a abrangencia do contrato e da verba
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> carregarClienteVerba(String accountId, String abrangenciaContrato, String abrangenciaVerba){
        Map<String, Object> response = new Map<String, Object>();
        try {
            if(String.isBlank(accountId)){
                throw new ContratoCtrlException('Id da conta não encontrado.');
            } else if(String.isBlank(abrangenciaContrato)) {
                throw new ContratoCtrlException('Abrangência do contrato não encontrada.');
            } else if(String.isBlank(abrangenciaVerba)){
                throw new ContratoCtrlException('Abrangência da verba não encontrada.');
            }
            //conta do cabecalho
            Account cabecalho = [SELECT Id, Matriz__c, Bandeira__c, Polo__c, BillingState FROM Account WHERE Id =: accountId];
            String queryString = 'SELECT Id, Name, SAPCode__c, SAPCodeDesc__c, PoloSAPCode__c, Matriz__c, MatrizSAPCodeText__c, Bandeira__c, BandeiraSAPCode__c, Polo__c FROM Account WHERE ';
            
            if(abrangenciaContrato == 'Matriz'){
                if(abrangenciaVerba == 'Matriz'){
                    queryString += 'Id = \'' + accountId + '\'';
                } else if(abrangenciaVerba == 'Bandeira' || abrangenciaVerba == 'Polo' || abrangenciaVerba == 'Loja'){
                    queryString += 'Matriz__c = \'' + cabecalho.Matriz__c + '\'';
                }
            } else if(abrangenciaContrato == 'Bandeira'){
                if(abrangenciaVerba == 'Bandeira') {
                    queryString += 'Id = \'' + accountId + '\'';
                } else if(abrangenciaVerba == 'Polo' || abrangenciaVerba == 'Loja'){
                    queryString += 'Bandeira__c = \'' + cabecalho.Bandeira__c + '\' AND Matriz__c = \'' + cabecalho.Matriz__c + '\'';
                }
            } else if (abrangenciaContrato == 'Polo'){
                if(abrangenciaVerba == 'Polo'){
                    queryString += 'Id = \'' + accountId + '\'';
                } else if(abrangenciaVerba == 'Loja') {
                    queryString += 'Polo__c = \'' + cabecalho.Polo__c + '\' AND Bandeira__c = \'' + cabecalho.Bandeira__c + '\' AND Matriz__c = \'' + cabecalho.Matriz__c + '\'';
                }
            } else if(abrangenciaContrato == 'Loja' && abrangenciaVerba == 'Loja'){
                queryString += 'Id = \'' + accountId + '\'';
            }
            
            queryString = queryString.contains('\'null\'') ? queryString.replace('\'null\'','\'\'') : queryString;
            
            switch on abrangenciaVerba {
                when 'Bandeira' {
                    queryString += ' ORDER BY Bandeira__c';
                } when 'Polo' {
                    queryString += ' ORDER BY Polo__c';
                } when 'Loja' {
                    queryString += ' ORDER BY Name';
                } 
            }

            System.debug('ContratoCtrl > queryString: ' + queryString);

            Map<String, PicklistModel> mapaPicklist = new Map<String, PicklistModel>();
            List<PicklistModel> lstPicklist = new List<PicklistModel>();
            PicklistModel item;
            for(sObject so :Database.Query(queryString)) {
                switch on abrangenciaVerba {
                    when 'Matriz' {
                        item = new PicklistModel();
                        item.id = (String) so.get('Id');
                        item.label = (String) so.get('MatrizSAPCodeText__c') + ' - ' + so.get('Matriz__c');
                        item.value = (String) so.get('MatrizSAPCodeText__c') + ' - ' + so.get('Matriz__c');
                        if(!mapaPicklist.containsKey((String) so.get('Matriz__c')) && so.get('Matriz__c') != null){
                            mapaPicklist.put((String) so.get('Matriz__c'), item);
                        }
                    } when 'Bandeira' {
                        item = new PicklistModel();
                        item.id = (String) so.get('Id');
                        item.label = (String) String.valueOf(so.get('BandeiraSAPCode__c')) + ' - ' + so.get('Bandeira__c');
                        item.value = (String) String.valueOf(so.get('BandeiraSAPCode__c')) + ' - ' + so.get('Bandeira__c');
                        if(!mapaPicklist.containsKey((String) so.get('Bandeira__c')) && so.get('Bandeira__c') != null){
                            mapaPicklist.put((String) so.get('Bandeira__c'), item);
                        }
                    } when 'Polo' {
                        item = new PicklistModel();
                        item.id = (String) so.get('Id');
                        item.label = String.valueOf(so.get('PoloSAPCode__c') + ' - ' + so.get('Polo__c'));
                        item.value = String.valueOf(so.get('PoloSAPCode__c') + ' - ' + so.get('Polo__c'));
                        if(!mapaPicklist.containsKey((String) so.get('Polo__c')) && so.get('Polo__c') != null){
                            mapaPicklist.put(String.valueOf(so.get('Polo__c')), item);
                        }
                    } when 'Loja' {
                        item = new PicklistModel();
                        item.id = (String) so.get('Id');
                        item.label = (String) so.get('SAPCodeDesc__c');
                        item.value = (String) so.get('SAPCodeDesc__c');
                        mapaPicklist.put((String) so.get('Id'), item);
                    } 
                }
			}
			response.put('sucesso', true);
			response.put('picklist', mapaPicklist.values());
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', 'Falha ao carregar o cliente da verba! ' + e.getMessage());
            System.debug('ContratoCtrl > carregarClienteVerba > Error: ' + e.getMessage() + ' Linha: ' + e.getLineNumber());
        }
        return response;
    }

    @AuraEnabled
    public static List<ContratoAnteriorModel> carregarContratoAnterior(String accountId, String abrangenciaContrato){
        List<ContratoAnteriorModel> response = new List<ContratoAnteriorModel>();
        System.debug('abrangenciaContrato Tela:'+ abrangenciaContrato);
        if(String.isBlank(abrangenciaContrato)){
            return response;
        }
        try {
            /*switch on abrangenciaContrato {
                when '1'{
                    abrangenciaContrato = 'Loja';
                }
                when '2'{
                    abrangenciaContrato = 'Matriz';
                }
                when '3'{
                    abrangenciaContrato = 'Grupo';
                }
                when '4'{
                    abrangenciaContrato = 'Bandeira';
                }
                when '5'{
                    abrangenciaContrato = 'Polo';
                }
            }*/
            //conta do cabecalho
            Account cabecalho = [SELECT Id, Matriz__c, Bandeira__c, Polo__c, BillingState FROM Account WHERE Id =: accountId];
            String queryString = 'SELECT Id, Name,  Name__c, Description, Status, AccountId, Account.Name, Account.SAPCode__c, Account.SAPCodeDesc__c, Account.PoloSAPCode__c, Account.Matriz__c, Account.MatrizSAPCodeText__c, Account.Bandeira__c, Account.BandeiraSAPCode__c, Account.Polo__c FROM Contract WHERE ';

            String filtro = '';
            if(abrangenciaContrato == 'Matriz'){
                //ABRANGENCIA DE MATRIZ
                filtro += '(BusinessPlanCoverage__c = \'2\' AND AccountId = \'' + accountId+ '\')';
                //ABRANGENCIA BANDEIRA, POLO OU LOJA
                filtro += ' OR ((BusinessPlanCoverage__c = \'4\' OR BusinessPlanCoverage__c = \'5\' OR BusinessPlanCoverage__c = \'1\') and Account.Matriz__c = \'' + cabecalho.Matriz__c + '\')';
            } else if(abrangenciaContrato == 'Bandeira'){
                //ABRANGENCIA DE BANDEIRA
                filtro += '(BusinessPlanCoverage__c = \'4\' AND AccountId = \'' + accountId + '\')';
                //ABRANGENCIA POLO OU LOJA
                filtro += ' OR ((BusinessPlanCoverage__c = \'5\' OR BusinessPlanCoverage__c = \'1\') AND Account.Bandeira__c = \'' + cabecalho.Bandeira__c + '\' AND Account.Matriz__c = \'' + cabecalho.Matriz__c + '\')';
            } else if (abrangenciaContrato == 'Polo'){
                //ABRANGENCIA DE POLO
                filtro += '(BusinessPlanCoverage__c = \'5\' AND AccountId = \'' + accountId + '\')';
                //ABRANGENCIA POLO OU LOJA
                filtro += ' OR (BusinessPlanCoverage__c = \'1\' AND Account.Polo__c = \'' + cabecalho.Polo__c + '\' AND Account.Bandeira__c = \'' + cabecalho.Bandeira__c + '\' AND Account.Matriz__c = \'' + cabecalho.Matriz__c + '\')';
            } else if(abrangenciaContrato == 'Loja'){
                filtro += 'AccountId = \'' + accountId + '\' AND BusinessPlanCoverage__c = \'1\'';
            }

            filtro = filtro.contains('\'null\'') ? filtro.replace('\'null\'','\'\'') : filtro;
            queryString+=filtro;

            System.debug('ContratoCtrl > filtro: ' + filtro);

            List<Id> contratosEncontrados = new List<Id>();
            for(sObject so :Database.Query(queryString)) {
                contratosEncontrados.add((String) so.get('Id'));
            }
            if(contratosEncontrados.size() > 0){
                for(Contract cont : [SELECT Id, Name, Name__c, Status, Registro__c, Account.Name, Account.SAPCode__c, Description FROM Contract WHERE Id IN :contratosEncontrados ORDER BY CreatedDate DESC]){
                    ContratoAnteriorModel contratoAnt = new ContratoAnteriorModel();
                    contratoAnt.idContrato = cont.id;
                    contratoAnt.codCliente = cont.Account.SAPCode__c;
                    contratoAnt.descContrato = cont.Name__c;
                    contratoAnt.nomeCliente =  cont.Account.Name;
                    contratoAnt.linkContratoLabel = cont.Registro__c;
                    contratoAnt.linkContrato = '/' + cont.id;
                    response.add(contratoAnt);
                }
            }
        } catch (Exception e) {
            System.debug('ContratoCtrl > carregarContratoAnterior > Error: ' + e.getMessage() + ' Linha: ' + e.getLineNumber());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : salvarContrato
	 |Data      : 18/12/2020
	 |Descrição : Salva a oportunidade e verbas no salesforce, realiza o envio para aprovação de acordo com o parametro "fase"
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> salvarContrato(String cabecalhoJSON, String verbasJSON, String baseCalculoJSON, String observacoes, String oportunidadeDraftId, String fase, String acao){
        
        System.debug('ContratoCtrl >>> salvarContrato');
        
        Map<String, Object> response = new Map<String, Object>();
        Savepoint savepoint = Database.setSavepoint(); //save point para dar rollback a partir desse ponto por segurança
        try {
            Map<String, String> cabecalho = (Map<String, String>) JSON.deserialize(cabecalhoJSON, Map<String, String>.class);
            Map<String, String> baseCalculo = (Map<String, String>) JSON.deserialize(baseCalculoJSON, Map<String, String>.class);
            List<VerbaModel> listaVerbas = (List<VerbaModel>) JSON.deserialize(verbasJSON, List<VerbaModel>.class);

            Opportunity opp = new Opportunity();
            //dados cabecalho
            opp.Id = String.isNotBlank(oportunidadeDraftId) ? oportunidadeDraftId : null;
            opp.RecordTypeId = RECORD_TYPE_OPORTUNIDADE_CONTRATO;
            opp.AccountId = cabecalho.get('idConta');
            opp.Name = '070'; //valor apenas para permitir o insert da oportunidade, mas a frente esse valor vai ser atualizado para um numero de registro sequencial com prefixo "070"
            opp.Denominacao__c = cabecalho.get('denominacao');
            opp.BusinessPlanStartDate__c = Date.valueOf(cabecalho.get('dataInicioContrato'));
            opp.BusinessPlanEndDate__c = Date.valueOf(cabecalho.get('dataTerminoContrato'));
            opp.CloseDate = Date.valueOf(cabecalho.get('dataTerminoContrato')); //validar esse campo (campo obrigatorio)
            opp.BusinessPlanCoverage__c = cabecalho.get('abrangenciaContrato');
            opp.Renovacao_automatica__c = Boolean.valueOf(cabecalho.get('renovacaoAutomatica'));
            opp.NovoContrato__c = Boolean.valueOf(cabecalho.get('tipoContrato'));
            //dados base de calculo
            opp.Inclui_PIS__c = Boolean.valueOf(baseCalculo.get('pis'));
            opp.Inclui_IPI__c = Boolean.valueOf(baseCalculo.get('ipi'));
            opp.Inclui_COFINS__c = Boolean.valueOf(baseCalculo.get('cofins'));
            opp.Inclui_ICMS__c = Boolean.valueOf(baseCalculo.get('icms'));
            opp.Inclui_ICMS_ST__c = Boolean.valueOf(baseCalculo.get('icmsst'));
            //dados observacoes
            opp.Description = observacoes;
            //criada em modo rascunho ou enviada para aprovação
            opp.StageName = fase;
            
            //se a oportunidadeDraftId estiver preenchida nao devo atribuir novamente o step 1
            if(fase == 'Enviado' && acao == 'enviar'){
                opp.StepAprovacao__c = 1;
            }
            
            Boolean oportunidadeDML = false;
            String mensagemErroOportunidade;
            String oportunidadeSalvaId;
            
            ContratoLongoPrazoTriggerHandler.byPassAprovacao = false;
            
            //se for update de uma oportunidade ja criada, a DML vai ser de update, caso contrato é insert
            Database.UpsertResult result = Database.upsert(opp, true);

            if (result.isSuccess()) {
                oportunidadeDML = true;
                oportunidadeSalvaId = result.getId();
                //vou pegar o valor do campo RegistroContrato__c e atribuir ao name da oportunidade
                Opportunity oportunidade = [SELECT Id, RegistroContrato__c FROM Opportunity WHERE Id =: oportunidadeSalvaId AND RecordTypeId =: RECORD_TYPE_OPORTUNIDADE_CONTRATO LIMIT 1];
                update new Opportunity(Id = oportunidade.Id, Name = oportunidade.RegistroContrato__c);
            } else {
                oportunidadeDML = false;
                for (Database.Error err : result.getErrors()) {
                    mensagemErroOportunidade = err.getMessage();
                }
            }

            if(oportunidadeDML){
                //se for um update de oportunidade ja criada, deleto todas as verbas e salvo novamente
                // if (String.isNotBlank(oportunidadeDraftId)) {
                //     List<BusinessPlanBudget__c> listaVerbasDelete = [SELECT Id FROM BusinessPlanBudget__c WHERE BusinessPlan__c =: oportunidadeDraftId AND RecordTypeId =: RECORD_TYPE_VERBA_CONTRATO];
                //     if(listaVerbasDelete.size() > 0){
                //         ContratoLongoPrazoTriggerHandler.acao = 'SalvandoContrato';
                //         delete listaVerbasDelete;
                //     }
                // }

                List<BusinessPlanBudget__c> listaVerbasInsert = new List<BusinessPlanBudget__c>();
                BusinessPlanBudget__c verba;
                for(VerbaModel v: listaVerbas){
                    verba = new BusinessPlanBudget__c();
                    verba.Id = String.isNotBlank(v.idVerba) ? v.idVerba : null;
                    verba.RecordTypeId = RECORD_TYPE_VERBA_CONTRATO;
                    verba.BudgetType__c = v.idTipoVerba; //id do tipo da verba
                    verba.BusinessPlan__c = oportunidadeSalvaId; //vinculo a verba a oportunidade criada
                    verba.Abrangencia__c = v.valueAbrangenciaVerba;
                    verba.Cliente__c = v.nomeClienteVerba;
                    verba.Unidade__c = v.unidade;
                    verba.Montante__c = v.montante;
                    verba.Forma_de_pagamento__c = v.formaPagamento;
                    verba.Periodicidade__c = v.periodicidade;
                    verba.ValidityStartDate__c = Date.valueOf(v.verbaValidadeDesde);
                    verba.ValidityFinalDate__c = Date.valueOf(v.verbaValidadeAte);
                    listaVerbasInsert.add(verba);
                }

                Boolean verbaDML = false;
                String mensagemErroVerba;
                ContratoLongoPrazoTriggerHandler.acao = 'SalvandoContrato';
                Database.UpsertResult[] srList = Database.Upsert(listaVerbasInsert, true);
                
                List<String> verbasSalvas = new List<String>(); 
                
                for (Database.UpsertResult sr : srList) {
                   if (sr.isSuccess()) {
                        verbasSalvas.add(sr.Id);
                        verbaDML = true;
                   } else {
                       verbaDML = false;
                       for (Database.Error err : sr.getErrors()) {
                           if(String.isNotBlank(mensagemErroVerba)){
                               mensagemErroVerba = err.getMessage(); //capturo a mensagem de erro da DML
                               break;
                            }
                        }   
                   }
                }
                
                List<BusinessPlanBudget__c> bpbList =  [SELECT Id, RecordTypeId , BudgetType__c , BusinessPlan__c , Abrangencia__c, Cliente__c , Unidade__c, Montante__c, 
                                                        Forma_de_pagamento__c, Periodicidade__c, ValidityStartDate__c , ValidityFinalDate__c, BudgetType__r.Name
                                                        FROM BusinessPlanBudget__c WHERE id IN: verbasSalvas];
                
                Map<String, Object> bpbMap = new Map<String, Object>();
                List<Object> mapObject = new List<Object>();
                 
                for( BusinessPlanBudget__c bpb : bpbList ) {
                    bpbMap.put('idTipoVerba', bpb.BudgetType__c);
                    bpbMap.put('descTipoVerba', bpb.BudgetType__r.Name);
                    bpbMap.put('descAbrangenciaVerba', bpb.Abrangencia__c);
                    bpbMap.put('valueAbrangenciaVerba', bpb.Abrangencia__c);
                  //  bpbMap.put('positionAbrangenciaVerba', );
                    bpbMap.put('idClienteVerba', cabecalho.get('idConta') );
                    bpbMap.put('nomeClienteVerba', bpb.Cliente__c);
                    bpbMap.put('montante', bpb.Montante__c);
                    bpbMap.put('unidade', bpb.Unidade__c);
                    bpbMap.put('formaPagamento', bpb.Forma_de_pagamento__c);
                    bpbMap.put('periodicidade', bpb.Periodicidade__c);
                    bpbMap.put('verbaValidadeDesde', bpb.ValidityStartDate__c);
                    bpbMap.put('verbaValidadeAte', bpb.ValidityFinalDate__c);
                    bpbMap.put('idVerba', bpb.Id);
                    
                    mapObject.add(bpbMap);
                    bpbMap = new Map<String, Object>();
                    
                }
                
                response.put('verbasAtualizadas', JSON.serialize(mapObject));
            	
                if(verbaDML){
                    //caminho feliz, oportunidade e verbas foram inseridas
                    response.put('oportunidadeSalvaId', oportunidadeSalvaId);
                    if(fase == 'Enviado'){
                        //verificando se a opp já esta em um processo de aprovação
                        String oppEmAprovacao = [SELECT Id, ProcessDefinitionId FROM ProcessInstance WHERE TargetObjectId =: oportunidadeSalvaId AND Status != 'Rejected']?.ProcessDefinitionId;
                        if(String.isBlank(oppEmAprovacao)){
                            //enviando oportunidade/contrato para aprovação                                               
                            Approval.ProcessSubmitRequest process = new Approval.ProcessSubmitRequest();
                            process.setProcessDefinitionNameOrId('Aprovacao_contrato');
                            process.setComments('Enviando solicitação para aprovação');
                            process.setObjectId(oportunidadeSalvaId);
                            process.setSubmitterId(Userinfo.getUserId()); 
                            Approval.ProcessResult resultProcessoAprovacao = Approval.process(process);
                            response.put('sucesso', resultProcessoAprovacao.isSuccess());
                            response.put('mensagemErro', resultProcessoAprovacao.isSuccess() ? 'Contrato enviado para aprovação com sucesso!' : 'Falha ao enviar contrato para aprovação! Por favor, contate os administradores do sistema.');
                        } else {
                            response.put('sucesso', true);
                            response.put('mensagemErro','Contrato atualizado com sucesso!');
                        }
                    } else {
                        // if(fase == 'Em digitação'){
                            response.put('sucesso', true);
                            response.put('mensagemErro', String.isNotBlank(oportunidadeDraftId) ? 'Contrato atualizado com sucesso!' : 'Contrato salvo com sucesso!');
                        // }
                    }
                } else {
                    response.put('sucesso', false);
                    response.put('mensagemErro', mensagemErroVerba);
                    Database.rollback(savepoint); //rollback
                }
            } else {
                //falha ao inserir a oportunidade
                response.put('sucesso', false);
                response.put('mensagemErro', mensagemErroOportunidade);
            }

        } catch (System.DmlException dmlEx) {

            response.put('sucesso', false);
            response.put('mensagemErro', dmlEx.getdmlMessage(0));
            Database.rollback(savepoint); //rollback

        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage() + ' linha: ' + e.getLineNumber());
            Database.rollback(savepoint); //rollback
        }
        return response;
    }

        
    /*******************************************************************************
	 |Método    : integrarSAP
	 |Data      : 18/01/2021
	 |Descrição : Realiza a chamada dos métodos necessários p/ realizar a integração com o SAP
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> integrarSAP(String oppId){
        Map<String, Object> response = new Map<String, Object>();
        try {
            Map<String, Object> SAP = ContratoService.sendContratoSAP(oppId);
            if(Boolean.valueOf(SAP.get('sucesso'))){
                Map<String, Object> contrato = converterOppContrato(String.valueOf(SAP.get('oppId')));
                    Boolean sucesso = Boolean.valueOf(contrato.get('sucesso'));    
                    response.put('sucesso', sucesso ? true : false);
                    response.put('mensagemErro', contrato.get('mensagemErro'));
                    response.put('idContrato', contrato.get('idContrato'));
            } else {
                response.put('sucesso', false);
                response.put('mensagemErro', SAP.get('mensagemErro'));            
            }
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());            
        }
        return response;
    }

    
    /*******************************************************************************
	 |Método    : carregarFaseOportunidade
	 |Data      : 28/12/2020
	 |Descrição : Carrega a fase da oportunidade para ser avaliada no botão "Integrar SAP"
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> carregarFaseOportunidade(String oppId){
        Map<String, Object> response = new Map<String, Object>();
        try {
            String fase = [SELECT StageName FROM Opportunity WHERE Id=: oppId AND RecordTypeId =: RECORD_TYPE_OPORTUNIDADE_CONTRATO].StageName;
            response.put('sucesso', true);
            response.put('fase', fase);
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('fase', '');
            response.put('mensagemErro', e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : converterOppContrato
	 |Data      : 22/12/2020
	 |Descrição : Converte a oportunidade em um contrato de fato
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> converterOppContrato(String oppId){
        
        Map<String, Object> response = new Map<String, Object>();
        Savepoint savepoint = Database.setSavepoint();
        
        try {
            Opportunity opp = [
                SELECT 
                    //dados cabecalho
                    Id,
                    Name,
                    AccountId,
                    Denominacao__c,
                    BusinessPlanStartDate__c,
                    BusinessPlanEndDate__c,
                    BusinessPlanCoverage__c,
                    Renovacao_automatica__c,
                    RegistroContrato__c,
                    //dados base calculo
                    Inclui_PIS__c,
                    Inclui_IPI__c,
                    Inclui_COFINS__c,
                    Inclui_ICMS__c,
                    Inclui_ICMS_ST__c,
                    //dados observacoes
                    Description
                    FROM 
                    Opportunity 
                    WHERE 
                    Id =: oppId
                    AND RecordTypeId =: RECORD_TYPE_OPORTUNIDADE_CONTRATO
            ];

            //Criando o contrato com base na oportunidade        
            Contract contrato = new Contract();
            contrato.Status = 'Draft';
            contrato.Oportunidade__c = oppId;
            contrato.RecordTypeId = RECORD_TYPE_CONTRATO_LONGO_PRAZO;
            contrato.Name = opp.Name;
            contrato.Name__c = opp.Denominacao__c;
            contrato.Registro__c = opp.RegistroContrato__c; //070
            contrato.StartDate = opp.BusinessPlanStartDate__c;
            contrato.DataFinal__c = opp.BusinessPlanEndDate__c;
            contrato.AccountId = opp.AccountId;
            //contrato.MotivoDistrato__c = 'Nenhum';
            //contrato.Dtdesonerar__c; 
            contrato.BusinessPlanCoverage__c = opp.BusinessPlanCoverage__c;
            contrato.Renovano_automatica__c = opp.Renovacao_automatica__c;
            contrato.Inclui_PIS__c = opp.Inclui_PIS__c;
            contrato.Inclui_IPI__c = opp.Inclui_IPI__c;
            contrato.Inclui_COFINS__c = opp.Inclui_COFINS__c;
            contrato.Inclui_ICMS__c = opp.Inclui_ICMS__c;
            contrato.Inclui_ICMS_ST__c = opp.Inclui_ICMS_ST__c;
            contrato.Description__c = opp.Description;

            Database.SaveResult contratoInsert = Database.Insert(contrato, false);
            Boolean contratoDML = false;
            String errorInsertContrato;
            Id idContrato;
            
            if (contratoInsert.isSuccess()) {
                update new Contract(Id = contratoInsert.getId(), Status = 'Activated');
                response.put('idContrato', contratoInsert.isSuccess() ? contratoInsert.getId() : '');
                idContrato =contratoInsert.getId();
                contratoDML = true;
            } else {
                for (Database.Error err : contratoInsert.getErrors()) {
                    errorInsertContrato = err.getMessage();
                    break;
                }
                response.put('sucesso', false);
                response.put('mensagemErro', 'Falha ao inserir contrato no Salesforce! Error: ' + errorInsertContrato); 
            }

            //relacionando as verbas com o contrato
            Boolean verbasDML = false;
            String errorUpdateVerbas;
            
            List<BusinessPlanBudget__c> verbas = new List<BusinessPlanBudget__c>();
            if(contratoDML){
                //relacionar o id do contrato com as mesmas verbas que estão relacionadas a oportunidade
                for(BusinessPlanBudget__c verba: [SELECT Id, Contrato__c FROM BusinessPlanBudget__c WHERE BusinessPlan__c =: oppId AND RecordTypeId =: RECORD_TYPE_VERBA_CONTRATO]){
                    verba.Contrato__c = contratoInsert.getId();
                    ContratoLongoPrazoTriggerHandler.acao = 'CriandoContrato';
                    verbas.add(verba);
                }
                
                Database.SaveResult[] verbasUpdate = Database.Update(verbas, true);
                
                for (Database.SaveResult result : verbasUpdate) {
                    if (result.isSuccess()) {
                        verbasDML = true;
                    } else {
                        for (Database.Error err : result.getErrors()) {
                            errorUpdateVerbas = err.getMessage();
                            break;
                        }
                    }
                }
                response.put('sucesso', verbasDML);
                response.put('mensagemErro', 'Falha ao atualizar as verbas do contrato no Salesforce! ' + errorUpdateVerbas);
            }

            //relacionando o detalhe da verba com o contrato
            Boolean detalheVerbasDML = false;
            String erroUpdateDetalheVerbas;
            
            if(contratoDML && verbasDML){
                List<BusinessPlanBudgetDetail__c> lstDetalhe = new List<BusinessPlanBudgetDetail__c>();
                for(BusinessPlanBudgetDetail__c detalhe: [SELECT Id, Contrato__c FROM BusinessPlanBudgetDetail__c WHERE BusinessPlanBudget__c IN: verbas]){
                    detalhe.Contrato__c = idContrato;
                    lstDetalhe.add(detalhe);
                }
                
                if( !lstDetalhe.isEmpty() ) { // Adicionado esta validação para resolver o Incidente: D-000079
                    
                    Database.SaveResult[] detalheVerbasUpdate = Database.Update(lstDetalhe, true);
                    for (Database.SaveResult result : detalheVerbasUpdate) {
                        if (result.isSuccess()) {
                            detalheVerbasDML = true;
                        } else {
                            for (Database.Error err : result.getErrors()) {
                                erroUpdateDetalheVerbas = err.getMessage();
                                break;
                            }
                        }
                    }
                    response.put('sucesso', detalheVerbasDML);
                    response.put('mensagemErro', 'Falha ao atualizar os detalhes da verba do contrato no Salesforce! ' + erroUpdateDetalheVerbas);
                    
                } else if( lstDetalhe.isEmpty() ) detalheVerbasDML = true; //Incidente: D-000079
                    
            }

            //se o contrato foi inserido e verbas foram atualizadas com sucesso, atualizo alguns campos na oportunidade
            Boolean oportunidadeDML = false;
            String errorUpdateOportunidade;

            if(contratoDML && verbasDML && detalheVerbasDML){
                
                ContratoLongoPrazoTriggerHandler.byPassAprovacao = false; //não vai rodar a trigger de workflow
                opp.ContractId = contratoInsert.getId();
                opp.StageName = 'Implantado';
                Database.SaveResult oportunidadeUpdate = Database.Update(opp, false);
                
                if (oportunidadeUpdate.isSuccess()) {
                    oportunidadeDML = true;
                } else {
                    for (Database.Error err : oportunidadeUpdate.getErrors()) {
                        errorUpdateOportunidade = err.getMessage();
                        break;
                    }
                    response.put('sucesso', false);
                    response.put('mensagemErro', 'Falha ao atualizar dados da oportunidade no Salesforce! ' + errorUpdateOportunidade); 
                }
            }

            //se todas as DMLs foram realizadas com sucesso
            if(contratoDML && oportunidadeDML && verbasDML && detalheVerbasDML){
                response.put('sucesso', true);
                response.put('mensagemErro', 'Contrato integrado e criado com sucesso!'); 
            } else {
                Database.rollback(savepoint);
            }
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());
            Database.rollback(savepoint);
        }
        return response;
    }

     /*******************************************************************************
	 |Método    : carregarPicklistAbrangenciaPorIdConta
	 |Data      : 21/01/2021
	 |Descrição : Retorna os valores do picklist de abrangencia baseado nos valores de Matriz, Bandeira, Polo e Loja da conta
	 ********************************************************************************/
    
    @AuraEnabled
    public static List<PicklistModel> carregarPicklistAbrangenciaPorIdConta(String idConta, String abrangencia){
        System.debug('ContratoCtrl > carregarPicklistAbrangenciaPorIdConta > idConta: ' + idConta);
        System.debug('ContratoCtrl > carregarPicklistAbrangenciaPorIdConta > abrangencia: ' + abrangencia);
        Map<String, PicklistModel> mapaFiltragemAbrangencia = new Map<String, PicklistModel>();
        try {
            Account cliente = [SELECT Id, Matriz__c, Polo__c, Bandeira__c FROM Account WHERE Id =: idConta];
            List<PicklistModel> pkAbrangencia;
            if(abrangencia == 'contrato'){
                pkAbrangencia  = picklistAbrangenciaContrato();
            } else if(abrangencia == 'verba') {
                pkAbrangencia  = picklistAbrangenciaVerba();
            }
            for(PicklistModel pk : pkAbrangencia){
                mapaFiltragemAbrangencia.put(pk.label, pk);
            }
            if(String.isBlank(cliente.Polo__c) && mapaFiltragemAbrangencia.containsKey('Polo')){
                mapaFiltragemAbrangencia.remove('Polo');
            }
            if(String.isBlank(cliente.Bandeira__c) && mapaFiltragemAbrangencia.containsKey('Bandeira')){
                mapaFiltragemAbrangencia.remove('Bandeira');
            }			
            if(String.isBlank(cliente.Matriz__c) && mapaFiltragemAbrangencia.containsKey('Matriz')){
                mapaFiltragemAbrangencia.remove('Matriz');
            }
        } catch (Exception e) {
            throw new ContratoCtrlException(e.getMessage());
        }
        return mapaFiltragemAbrangencia.values();
    }

    /*******************************************************************************
	 |Método    : carregarPicklists
	 |Data      : 27/11/2020
	 |Descrição : Retona um mapa com os valores dos picklists necessarios para alimentar a tela 
	 ********************************************************************************/
    
    @AuraEnabled
    public static Map<String, Object> carregarPicklists(String idConta){
        System.debug('ContratoCtrl > carregarPicklists');
        Map<String, Object> response = new Map<String, Object>();
        try {
            response.put('picklistAbrangenciaContrato', carregarPicklistAbrangenciaPorIdConta(idConta, 'contrato'));
            response.put('picklistAbrangenciaVerba', picklistAbrangenciaVerba());
            response.put('picklistTipoVerba', picklistTipoVerba());
            response.put('picklistUnidade', ObjectPicklistUtils.getPicklistOptions('BusinessPlanBudget__c', 'Unidade__c'));
            response.put('picklistFormaPagamento', ObjectPicklistUtils.getPicklistOptions('BusinessPlanBudget__c', 'Forma_de_pagamento__c'));
            response.put('picklistPeriodicidade', ObjectPicklistUtils.getPicklistOptions('BusinessPlanBudget__c', 'Periodicidade__c'));
            response.put('sucesso', true);
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', 'ContratoCtrl > carregarPicklists: ' + e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : picklistAbrangenciaContrato
	 |Data      : 02/12/2020
	 |Descrição : Retorna a lista de valores para o picklist "abrangencia" no cabecalho
	 ********************************************************************************/

    public static List<PicklistModel> picklistAbrangenciaContrato(){
        System.debug('ContratoCtrl > picklistAbrangenciaContrato');
        List<PicklistModel> pickListValuesList= new List<PicklistModel>();
        try {
            Schema.DescribeFieldResult fieldResult = Opportunity.BusinessPlanCoverage__c.getDescribe();
            List<Schema.PicklistEntry> picklistEntry = fieldResult.getPicklistValues();
            PicklistModel picklist;
            for( Schema.PicklistEntry p : picklistEntry){
                if(p.getLabel() != 'Grupo'){
                    picklist = new PicklistModel();
                    String label = p.getLabel();
                    switch on label {
                        when 'Matriz' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 1;
                        } when 'Bandeira' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 2;
                        } when 'Polo' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 3;
                        } when 'Loja' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 4;
                        }
                    }
                    pickListValuesList.add(picklist);
                }
            }      
        } catch (Exception e) {
            throw new ContratoCtrlException(e.getMessage());
        }
        return pickListValuesList;
    }

    /*******************************************************************************
	 |Método    : picklistAbrangenciaVerba
	 |Data      : 02/12/2020
     |Descrição : Retorna a lista de valores para o picklist "abrangencia" p/o modal de add verba
     esse metodo foi criado pois os values do picklist de abrangencia da oportunidade sao diferentes do objeto verba
	 ********************************************************************************/

    @AuraEnabled
    public static List<PicklistModel> picklistAbrangenciaVerba(){
        System.debug('ContratoCtrl >>> picklistAbrangenciaVerba');
        List<PicklistModel> pickListValuesList= new List<PicklistModel>();
        try {
            Schema.DescribeFieldResult fieldResult = BusinessPlanBudget__c.Abrangencia__c.getDescribe();
            List<Schema.PicklistEntry> picklistEntry = fieldResult.getPicklistValues();
            PicklistModel picklist;
            for( Schema.PicklistEntry p : picklistEntry){
                if(p.getLabel() != 'Grupo'){
                    picklist = new PicklistModel();
                    String label = p.getLabel();
                    switch on label {
                        when 'Matriz' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 1;
                        } when 'Bandeira' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 2;
                        } when 'Polo' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 3;
                        } when 'Loja' {
                            picklist.label = label;
                            picklist.value = p.getValue();
                            picklist.position = 4;
                        }
                    }
                    pickListValuesList.add(picklist);
                }
            }      
        } catch (Exception e) {
            throw new ContratoCtrlException(e.getMessage());
        }
        return pickListValuesList;
    }

    /*******************************************************************************
	 |Método    : checkCustomPermission
	 |Data      : 26/01/2020
	 |Descrição : Retorna um boleano indicando se o usuário ou perfil tem acesso a determinada permissão personalizada
	 ********************************************************************************/

    private static Boolean checkCustomPermission(String customPermissionAPIName) {
        Boolean possuiPermissao = FeatureManagement.checkPermission(customPermissionAPIName);
        return possuiPermissao;
    }

    /*******************************************************************************
	 |Método    : picklistTipoVerba
	 |Data      : 02/12/2020
	 |Descrição : Retorna a lista de valores para o picklist "abrangencia" no cabecalho
	 ********************************************************************************/

    @AuraEnabled
    public static List<PicklistModel> picklistTipoVerba(){
        System.debug('ContratoCtrl >>> picklistTipoVerba');
        List<PicklistModel> picklist = new List<PicklistModel>();
        try {
            PicklistModel pm;
            for(BudgetType__c bt: [SELECT Id, Name, ConditionType__c, BusinessPlanDetailRequired__c FROM BudgetType__c WHERE Classification__c = 'CONTRATO' ORDER BY Name]){
                pm = new PicklistModel();
                pm.id = bt.id;
                pm.label = bt.Name;
                pm.value = bt.Name;
                pm.requiredDetail = bt.BusinessPlanDetailRequired__c;
                picklist.add(pm); 
            }   
        } catch (Exception e) {
            throw new ContratoCtrlException(e.getMessage());
        }
        return picklist;
    }

    /*******************************************************************************
	 |Método    : picklistFamilias
	 |Data      : 01/02/2021
	 |Descrição : Retorna a lista de valores para o picklist "familias" no detalhe da verba
	 ********************************************************************************/

    @AuraEnabled
    public static List<PicklistModel> picklistFamilias(){
        System.debug('ContratoCtrl >>> picklistFamilias');
        List<PicklistModel> picklist = new List<PicklistModel>();
        try {
            Id RECORD_TYPE_FAMILIA = Schema.SObjectType.ProductFamily__c.getRecordTypeInfosByDeveloperName().get('CommercialFamilies').getRecordTypeId();
            PicklistModel pm;
            for(ProductFamily__c pf: [SELECT Id, Name, FamilySAPCode__c, FamilyGroup__r.Name FROM ProductFamily__c WHERE IsActive__c = true AND RecordTypeId =: RECORD_TYPE_FAMILIA ORDER BY Name]){
                pm = new PicklistModel();
                pm.id = pf.id;
                pm.label = pf.Name;
                pm.value = pf.Name;
                picklist.add(pm); 
            }   
        } catch (Exception e) {
            throw new ContratoCtrlException(e.getMessage());
        }
        return picklist;
    }

    /*******************************************************************************
	 |Método    : picklistPeriodicidadeDetalhe
	 |Data      : 02/02/2021
	 |Descrição : Retorna a lista de valores para o picklist "periodo" no detalhe da verba
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> picklistPeriodicidadeDetalhe(){
        Map<String, Object> response = new Map<String, Object>();
        try {
            response.put('sucesso', true);
            response.put('picklist', ObjectPicklistUtils.getPicklistOptions('BusinessPlanBudget__c', 'PeriodicidadeDetalhe__c'));
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Método    : picklistTipoDetalhe
	 |Data      : 02/02/2021
	 |Descrição : Retorna a lista de valores para o picklist "tipo de detalhe" no detalhe da verba
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> picklistTipoDetalhe(){
        Map<String, Object> response = new Map<String, Object>();
        try {
            response.put('sucesso', true);
            response.put('picklist', ObjectPicklistUtils.getPicklistOptions('BusinessPlanBudgetDetail__c', 'ExtraPointType__c'));
        } catch (Exception e) {
            response.put('sucesso', false);
            response.put('mensagemErro', e.getMessage());
        }
        return response;
    }

    /*******************************************************************************
	 |Autor     : Fernanda Faria
	 |Método    : validaEdicao
	 |Data      : 26/01/2021
	 ********************************************************************************/

    @AuraEnabled
    public static void validaEdicao(Id opportunityId){
        Opportunity opp = [SELECT  (SELECT Id, LastActor.Name FROM ProcessInstances), Id, FlaggedForDeletion__c, Final_Approval__c, BusinessPlanStatus__c, BusinessPlanEndDate__c, Account.DistributionChannelSAPCode__c, Account.CustomerGroupSAPCode__c, Account.Approach__c, Account.SalesTeamSAPCode__c FROM Opportunity WHERE Id = :opportunityId];
        if(opp.FlaggedForDeletion__c){
            throw new AuraHandledException('Não é possível editar um registro marcado para exclusão');
        }
        List<ProcessInstance> listaPI = [SELECT Id, TargetObjectid, Status,
                                            (SELECT Id, StepStatus, Comments, IsPending, ActorId FROM StepsAndWorkitems) 
                                        FROM ProcessInstance where TargetObjectId = :opp.Id];
        //Caso esteja em aprovação, apenas o aprovador atualpoderá editá-lo
        Set<Id> idsAprovadoresAlcada = new Set<Id>();
        if(opp.BusinessPlanStatus__c.equals('UnderApproval')){
            for(ProcessInstance processInstance : listaPI){
                if(!processInstance.StepsAndWorkitems.isEmpty()){
                    if(processInstance.Status == 'Pending'){
                        for(ProcessInstanceHistory processHistory : processInstance.StepsAndWorkitems){
                            if(processHistory.StepStatus == 'Pending'){
                                idsAprovadoresAlcada.add(processHistory.ActorId);
                            }
                        }
                    }
                }
            }
            if(!idsAprovadoresAlcada.contains(UserInfo.getUserId())) throw new AuraHandledException('Não é possível editar um contrato com status \"' + Utils.getMapPicklist('Opportunity', 'BusinessPlanStatus__c').get(opp.BusinessPlanStatus__c)+'\"');
        }
    }
    
    /*******************************************************************************
	 |Autor     : Felipe Monteiro
	 |Método    : salvarDetalheDaVerba
	 |Data      : 05/02/2021
	 |Descrição : Método para salvar o detalhamento da verba
	 ********************************************************************************/

    @AuraEnabled
    public static Map<String, Object> salvarDetalheDaVerba(String data){
       
        System.debug('## Data detalhe verba: ' + data);
        
        Map<String, Object> response = new Map<String, Object>();
        
        Map<String, String> dataType = (Map<String, String>) JSON.deserialize(data, Map<String, String>.class);

        BusinessPlanBudgetDetail__c  bpbDetail = new BusinessPlanBudgetDetail__c();
        
        bpbDetail.BusinessPlanBudget__c = dataType.get('idVerba');
        bpbDetail.Oportunidade__c = dataType.get('oppId');
        bpbDetail.Quantidade_de_Familia__c = dataType.get('qtdFamilias') == '' ? 0 : Decimal.valueOf( dataType.get('qtdFamilias') );
        bpbDetail.Period__c = String.isNotBlank(dataType.get('periodo')) ? dataType.get('periodo') : '';
        bpbDetail.Participacao__c = dataType.get('pctParticipacao') == '' ? 0 : Decimal.valueOf( dataType.get('pctParticipacao') );
        bpbDetail.StoreQuantity__c = dataType.get('qtdLojas') == '' ? 0 : Decimal.valueOf( dataType.get('qtdLojas') );
        bpbDetail.Quantidade_de_Pontos__c = dataType.get('qtdPontos') == '' ? 0 : Decimal.valueOf( dataType.get('qtdPontos') );
        bpbDetail.NumberPhotos__c = dataType.get('qtdFotos') == '' ? 0 : Decimal.valueOf( dataType.get('qtdFotos') );
        bpbDetail.ExtraPointType__c = String.isNotBlank(dataType.get('tipoDetalhe')) ? dataType.get('tipoDetalhe') : '';
        bpbDetail.Familia__c = String.isNotBlank(dataType.get('familia')) ? dataType.get('familia') : '';
        
        try {
            insert bpbDetail;
            
            System.debug('## Save Detail');
            System.debug(bpbDetail);
            
            BusinessPlanBudgetDetail__c bpbReturn = [SELECT Id, BusinessPlanBudget__c, BusinessPlanBudget__r.BudgetType__r.name, Quantidade_de_Familia__c,
                                                            Period__c, Familia__c, Participacao__c, StoreQuantity__c, Quantidade_de_Pontos__c, NumberPhotos__c, ExtraPointType__c
                                                     FROM BusinessPlanBudgetDetail__c WHERE id =: bpbDetail.Id];
            response.put('data', bpbReturn);
        	response.put('sucesso', true);
            
        } catch ( Exception ex ) {
            response.put('sucesso', false);
            response.put('mensagemErro', ex.getMessage() + ' linha: ' + ex.getLineNumber());
        }
        
        return response;
    }

    /*******************************************************************************
	 |Autor     : Felipe Monteiro
	 |Método    : deletarDetalheDaVerba
	 |Data      : 05/02/2021
	 |Descrição : Método para deletar o detalhamento da verba
	 ********************************************************************************/
    
    @AuraEnabled
    public static Map<String, Object> deletarDetalheDaVerba(String idDetail){
        
        Map<String, Object> response = new Map<String, Object>();
        
        if( idDetail != NULL ) {
                try {
                    delete [SELECT Id FROM BusinessPlanBudgetDetail__c WHERE id =: idDetail];
                    response.put('sucesso', true);
                } catch ( Exception ex ) {
                    response.put('sucesso', false);
                    response.put('mensagemErro', ex.getMessage() + ' linha: ' + ex.getLineNumber());
                }
        }

        return response;
    }
    
    /*******************************************************************************
	 |Autor     : Felipe Monteiro
	 |Método    : deletarVerba
	 |Data      : 10/02/2021
	 |Descrição : Método para deletar o detalhamento da verba
	 ********************************************************************************/
    
    @AuraEnabled
    public static Map<String, Object> deletarVerba(String verbaId, List<String> verbas){
        
        Map<String, Object> response = new Map<String, Object>();
        
        if( verbaId != NULL ) {
                try {
                    ContratoLongoPrazoTriggerHandler.acao = 'SalvandoContrato';
                    delete [SELECT Id FROM BusinessPlanBudget__c WHERE id =: verbaId];
                    
                    
        
				    List<BusinessPlanBudgetDetail__c> bpbDetailList = [SELECT Id, BusinessPlanBudget__c, BusinessPlanBudget__r.BudgetType__r.Name, Quantidade_de_Familia__c,
                                                           			 Period__c, Familia__c, Participacao__c, StoreQuantity__c, Quantidade_de_Pontos__c, NumberPhotos__c, ExtraPointType__c
                                                           FROM BusinessPlanBudgetDetail__c WHERE BusinessPlanBudget__c IN: verbas ];
                    
                     
                    response.put('bpbDetails', bpbDetailList);
                    response.put('sucesso', true);
                } catch ( Exception ex ) {
                    response.put('sucesso', false);
                    response.put('mensagemErro', ex.getMessage() + ' linha: ' + ex.getLineNumber());
                }
        } else {
            response.put('sucesso', false);
            response.put('mensagemErro', 'Id nulo.');
        }

        return response;
    }
    
    public class PicklistModel {
        @AuraEnabled public String id;
        @AuraEnabled public String label;
        @AuraEnabled public String value;
        @AuraEnabled public Integer position;
        @AuraEnabled public Boolean requiredDetail;
    }

    public class ContratoAnteriorModel {
        @AuraEnabled public String idContrato;
        @AuraEnabled public String nomeCliente;
        @AuraEnabled public String codCliente;
        @AuraEnabled public String descContrato;
        @AuraEnabled public String linkContrato;
        @AuraEnabled public String linkContratoLabel;
    }

    public class VerbaModel {
        @AuraEnabled public String idVerba;
        @AuraEnabled public String descVerba;
        @AuraEnabled public String idTipoVerba;
        @AuraEnabled public String descTipoVerba;
        @AuraEnabled public String valueAbrangenciaVerba;
        @AuraEnabled public String descAbrangenciaVerba;
        @AuraEnabled public String idClienteVerba;
        @AuraEnabled public String nomeClienteVerba;
        @AuraEnabled public String descClienteOneracao;
        @AuraEnabled public Double montante;
        @AuraEnabled public String unidade;
        @AuraEnabled public String formaPagamento;
        @AuraEnabled public String periodicidade;
        @AuraEnabled public String verbaValidadeDesde;
        @AuraEnabled public String verbaValidadeAte;
        @AuraEnabled public Boolean oneracao;
        @AuraEnabled public String abrangenciaOneracao;
        @AuraEnabled public String percentualOneracao;
        @AuraEnabled public String oneracaoValidaDesde;
        @AuraEnabled public String oneracaoValidaAte;
    }

    public class DetalheVerbaModel {
        @AuraEnabled public String idDetalhe;
        @AuraEnabled public String percentParticipacao;
        @AuraEnabled public String qtdLojas;
        @AuraEnabled public String qtdFotos;
        @AuraEnabled public String qtdFamilias;
        @AuraEnabled public String qtdPontos;
        @AuraEnabled public String descFamilia;
        @AuraEnabled public String descTipoVerba;
        @AuraEnabled public String descTipoDetalhe;
        @AuraEnabled public String periodo;
        @AuraEnabled public String verbaId;
    }

    public class ContratoCtrlException extends Exception {}

}